using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using FontAwesome.WPF;

namespace Xaml_Jatek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int huzasokSzama=0;
         FontAwesomeIcon elozoKartya = FontAwesomeIcon.None;
        //Dobókocka
        Random dobokocka = new Random();
        //6 lapos kártyacsomagot befogadó kártyahely (tömb) létrehozása - ide csak FontAwesomeIcon-ok helyezhetők.
        FontAwesomeIcon[] kartyak = new FontAwesome.WPF.FontAwesomeIcon[6];

        TimeSpan visszalevoIdo;
        DispatcherTimer ingaora;

        //stopperóra a reakció idő méréséhez
        Stopwatch stopper = new Stopwatch();
        private long utolsoReakcioIdo;

        //Az összes reakciót eltároljuk, hogy az átlagot tudjuk számítani
        List<long> ossesReakcio = new List<long>(); 

        public MainWindow()
        { //Ez a függvény akkor fut le, amikor megjelenik az ablak.
            InitializeComponent();

            //A kártyahely feltöltése kártyákkal
            kartyak[0] = FontAwesome.WPF.FontAwesomeIcon.Car;
            kartyak[1] = FontAwesome.WPF.FontAwesomeIcon.SnowflakeOutline;
            kartyak[2] = FontAwesome.WPF.FontAwesomeIcon.Briefcase;
            kartyak[3] = FontAwesome.WPF.FontAwesomeIcon.Book;
            kartyak[4] = FontAwesome.WPF.FontAwesomeIcon.Male;
            kartyak[5] = FontAwesome.WPF.FontAwesomeIcon.Female;

            //Felparaméterezzük az ingaóránkat
            //másodpercenként adjon egy eseményt
            ingaora = new DispatcherTimer(
                TimeSpan.FromSeconds(1) // egy másodpercenként adjon egyeseményt
                ,DispatcherPriority.Normal //semmi különleges, semmi fontos, nem számít néhány másodperc
                ,IngaoraUt  //ezt az eljárást fogja hívni az óra
                ,Application.Current.Dispatcher //olyan üzenetszórót használunk, ami a felülethez küldi az eseményt, ezért tudunk íírni rá
                );
            //mivel azonnal elindul ezért meg kell állítani!!
            ingaora.Stop();
        }
        /// <summary>
        /// Ezt a függvényt hívja az óra minden alkalommal amikor üt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IngaoraUt(object sender, EventArgs e)
        {
            //ey másodperccel csökkentem az időt
            visszalevoIdo = visszalevoIdo.Add(TimeSpan.FromSeconds(-1));
            //szöveg belsejáben csere
            //ContdownLabel.Content = $"Visszaszámlálás: {visszalevoIdo}";
            //ContdownLabel.Content = $"Visszaszámlálás: {visszalevoIdo.Minutes:00}:{visszalevoIdo.Seconds:00}";
            ContdownLabel.Content = $"Visszaszámlálás: {visszalevoIdo.ToString(@"mm\:ss")}";
            if (visszalevoIdo==TimeSpan.Zero)
            {
                JatekVege();
            }
        }


        private void JatekKezdete()
        {
            visszalevoIdo = TimeSpan.FromSeconds(55);

            ingaora.Start();
        }

        private void JatekVege()
        {
            ingaora.Stop();
        }



        private void ShowNewCardButton_Click(object sender, RoutedEventArgs e)
        {
            UjKartyaHuzasa();
        }
        /// <summary>
        /// Egy kocka dobása és új kártya húzása a dobás alapján
        /// </summary>
        private void UjKartyaHuzasa()
        {
            huzasokSzama++;


            if (huzasokSzama == 2)
            {
                //todo: Ez a játék kezdete, ki is lehetne szervezni


                NoButton.IsEnabled = true;
                YesButton.IsEnabled = true;
                //Ezt későbbiekben visszatesszük
                //PartiallyButton.IsEnabled = true;

                //Innentől kezdve csak az igen és a nem gomb kell - ők adják az új kártyát
                //Az új kártyakérő gombot letiltjuk
                ShowNewCardButton.IsEnabled = false;

                JatekKezdete();
            }


            //dobunk dobókockával,
           
            var dobas = dobokocka.Next(0, 5);
            //System.Diagnostics.Debug.WriteLine(dobas);

            //Elmentjük az aktuális kártyát, ami a húzás után az előző kártya lesz.
            elozoKartya = CardPlaceRight.Icon;

            //eltüntetjük az előző kártyát
            var animationOut = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(100));
            CardPlaceRight.BeginAnimation(OpacityProperty, animationOut);

            //ez kijelöli a kártyát, amelyiket meg kel jelenítenünk.
            CardPlaceRight.Icon = kartyak[dobas];

            //nem foglalkozunk esetszétválasztással, mindíg újraindítjuk
            stopper.Restart();

            //megjelenítjük az új kártyát
            var animationIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(100));
            CardPlaceRight.BeginAnimation(OpacityProperty, animationIn);
        }



        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
           // Debug.WriteLine(e.Key);
            if (huzasokSzama<2)
            { //még nincs két kártya, tehát a gombok nem élnek.
                return; //ebben az esetben a függvényvégrehajtása felfüggesztődik, visszatér a hívóhoz.
            }

            if (e.Key == Key.Left)
            {//balra nyíl
                NoAnswer();
            }
            if (e.Key == Key.Right)
            {//jobba nyíl
                YesAnswer();
            }
            if (e.Key == Key.Down)
            { }
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            NoAnswer();
        }

        private void PartiallyButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            YesAnswer();
        }

        private void NoAnswer()
        {
            ReakcióidoEsPontszamitas();
            if (elozoKartya == CardPlaceRight.Icon)
            { // egyezik a két kártya tehát a válasz helytelen!
                System.Diagnostics.Debug.WriteLine("A válasz hibás");
                AValaszHibas();
            }
            else
            { //A válasz helyes
                System.Diagnostics.Debug.WriteLine("A válasz helyes");
                AValaszHelyes();
            }
            UjKartyaHuzasa();
        }

        private void YesAnswer()
        {
            ReakcióidoEsPontszamitas();
            if (elozoKartya == CardPlaceRight.Icon)
            {//valóban egyezik a két kártya
                System.Diagnostics.Debug.WriteLine("A válasz helyes");
                AValaszHelyes();
            }
            else
            {// nem egyezik
                System.Diagnostics.Debug.WriteLine("A válasz hibás");
                AValaszHibas();
            }
            UjKartyaHuzasa();
        }

        /// <summary>
        /// reakcióidő mérése
        /// átlagos reakcióidő mérése
        /// pont számítás
        /// események megjelenítése
        /// </summary>
        private void ReakcióidoEsPontszamitas()
        {
            stopper.Stop();
            utolsoReakcioIdo = stopper.ElapsedMilliseconds;

            //az utolsó reakcióidőt elmentjük a listára
            ossesReakcio.Add(utolsoReakcioIdo);

            //átlagos reakcióidő =?
           long reakciokOsszege = 0;

           for (int i = 0; i < ossesReakcio.Count; i++)
            {
                reakciokOsszege += ossesReakcio[i];
            }
            var reakciokAtlaga = reakciokOsszege / ossesReakcio.Count;
            ReakcioLabel.Content = $"Reakció: {utolsoReakcioIdo}/{reakciokAtlaga}";


        }

        private void AValaszHelyes()
        {
            CardSpaceLeft.Foreground = Brushes.Green;
            CardSpaceLeft.Icon = FontAwesomeIcon.Check;
            AValaszLAssuEltunese();

        }



        private void AValaszHibas()
        {
            CardSpaceLeft.Foreground = Brushes.Red;
            CardSpaceLeft.Icon = FontAwesomeIcon.Times;
            AValaszLAssuEltunese();
        }

        private void AValaszLAssuEltunese()
        {
            //todo: megpróbálni kiszervezni a program elejére
            var animation = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(1000));
            CardSpaceLeft.BeginAnimation(OpacityProperty, animation);
        }

    }
}

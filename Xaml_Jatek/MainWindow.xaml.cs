﻿using System;
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
                NoButton.IsEnabled = true;
                YesButton.IsEnabled = true;
                //Ezt későbbiekben visszatesszük
                //PartiallyButton.IsEnabled = true;

                //Innentől kezdve csak az igen és a nem gomb kell - ők adják az új kártyát
                //Az új kártyakérő gombot letiltjuk
                ShowNewCardButton.IsEnabled = false;
            }




            //dobunk dobókockával,
           
            var dobas = dobokocka.Next(0, 5);
            //System.Diagnostics.Debug.WriteLine(dobas);

            //Elmentjük az aktuális kártyát, ami a húzás után az előző kártya lesz.
            elozoKartya = CardPlaceRight.Icon;

            //ez kijelöli a kártyát, amelyiket meg kel jelenítenünk.
            CardPlaceRight.Icon = kartyak[dobas];
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
            var animation = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(1000));
            CardSpaceLeft.BeginAnimation(OpacityProperty, animation);
        }

    }
}

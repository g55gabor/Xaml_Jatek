using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Xaml_Jatek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowNewCard_Click(object sender, RoutedEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("Megnyomtad a gombot");
            // Kell egy hatlapos kártyacsomag,
            var card1 = FontAwesome.WPF.FontAwesomeIcon.Car;
            var card2 = FontAwesome.WPF.FontAwesomeIcon.SnowflakeOutline;
            var card3 = FontAwesome.WPF.FontAwesomeIcon.Briefcase;
            var card4 = FontAwesome.WPF.FontAwesomeIcon.Book;
            var card5 = FontAwesome.WPF.FontAwesomeIcon.Male;
            var card6 = FontAwesome.WPF.FontAwesomeIcon.Female;

            //dobunk dobókockával,
            //ez kijelöli a kártyát, amelyiket meg kel jelenítenünk.
            CardPlaceRight.Icon = card6;
        }
    }
}

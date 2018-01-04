﻿using System;
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
        int huzasokSzama=0;
   
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowNewCardButton_Click(object sender, RoutedEventArgs e)
        {

            huzasokSzama++;

           if (huzasokSzama==2)
            {
                NoButton.IsEnabled = true;
                YesButton.IsEnabled = true;
                ShowNewCardButton.IsEnabled = true;
            }


            // Kell egy hatlapos kártyacsomag,
            var kartyak = new FontAwesome.WPF.FontAwesomeIcon[6];
            kartyak[0]= FontAwesome.WPF.FontAwesomeIcon.Car;
            kartyak[1] = FontAwesome.WPF.FontAwesomeIcon.SnowflakeOutline;
            kartyak[2] = FontAwesome.WPF.FontAwesomeIcon.Briefcase;
            kartyak[3] = FontAwesome.WPF.FontAwesomeIcon.Book;
            kartyak[4] = FontAwesome.WPF.FontAwesomeIcon.Male;
            kartyak[5] = FontAwesome.WPF.FontAwesomeIcon.Female;

            //dobunk dobókockával,
            var dobokocka = new Random();
            var dobas = dobokocka.Next(0, 5);
            //System.Diagnostics.Debug.WriteLine(dobas);


            //ez kijelöli a kártyát, amelyiket meg kel jelenítenünk.
            CardPlaceRight.Icon = kartyak[dobas];
        }
    }
}

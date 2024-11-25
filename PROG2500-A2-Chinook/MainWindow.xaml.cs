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

namespace PROG2500_A2_Chinook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
  
        public Pages.HomePage homePage { get; set; }
        public Pages.ArtistPage artistPage { get; set; }
        public Pages.GenrePage genrePage { get; set; }
        public Pages.AlbumPage albumPage { get; set; }
        public Pages.TracksPage tracksPage { get; set; }
        public Pages.MusicCatalogPage musicCatalogPage { get; set; }
        public Pages.CustomerOrderSearchPage customerOrderSrchPage { get; set; }


    public MainWindow()
        {
            InitializeComponent();
            homePage = new Pages.HomePage();
            artistPage = new Pages.ArtistPage();
            genrePage = new Pages.GenrePage();
            albumPage = new Pages.AlbumPage();
            tracksPage = new Pages.TracksPage();
            musicCatalogPage = new Pages.MusicCatalogPage();
            customerOrderSrchPage = new Pages.CustomerOrderSearchPage();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            //Navigate to the HomePage 
            mainFrame.NavigationService.Navigate(new Pages.HomePage());


        }

        private void Artists_Click(object sender, RoutedEventArgs e)
        {
            //Navigate to the ArtistsPage
            mainFrame.NavigationService.Navigate(new Pages.ArtistPage());
        }

        private void Genre_Click(object sender, RoutedEventArgs e)
        {
            //Navigate to the GenrePage
            mainFrame.NavigationService.Navigate(new Pages.GenrePage());
        }

        private void Album_Click(object sender, RoutedEventArgs e)
        {
            //Navigate to the AlbumPage
            mainFrame.NavigationService.Navigate(new Pages.AlbumPage());
        }

        private void Tracks_Click(object sender, RoutedEventArgs e)
        {
            //Navigate to the TracksPage
            mainFrame.NavigationService.Navigate(new Pages.TracksPage());
        }

        private void MusicCatalogButton_Click(object sender, RoutedEventArgs e)
        {
            //Navigate to the MusicCatalogPage
            mainFrame.NavigationService.Navigate(new Pages.MusicCatalogPage());
        }

        private void CustomerOrderSrchPageButton_Click(object sender, RoutedEventArgs e)
        {
            //Navigate to the CustomerOrderSearchPage
            mainFrame.NavigationService.Navigate(new Pages.CustomerOrderSearchPage());
        }
    }
}

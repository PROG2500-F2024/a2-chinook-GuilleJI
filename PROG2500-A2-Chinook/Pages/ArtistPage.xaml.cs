using Microsoft.EntityFrameworkCore;
using PROG2500_A2_Chinook.Data;
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

namespace PROG2500_A2_Chinook.Pages
{
    /// <summary>
    /// Interaction logic for ArtistPage.xaml
    /// </summary>
    public partial class ArtistPage : Page
    {
        private ChinookContext _context = new ChinookContext();
        CollectionViewSource artistViewSource = new CollectionViewSource();
        public ArtistPage()
        {
            InitializeComponent();
            //Tie the markup viewsource object to the C# code viewsource object
            artistViewSource = (CollectionViewSource)FindResource(nameof(artistViewSource));

            //Use the dbContext to tell EntityFramework to load the data to use on this page
            _context.Artists.Load();

            //Set the viewsource data source to use the artist data collection (dbset)
            artistViewSource.Source = _context.Artists.Local.ToObservableCollection();

            // Bind the initial list of artists to the listbox
            listArtistSearchResults.ItemsSource = _context.Artists.Local.ToObservableCollection();

        }

        //private void btnSearch_Click(object sender, RoutedEventArgs e)
        //{
        //    //Linq 
        //    //Relieve a single value, to put in a single label. 
        //    //Defining out LINQ query
        //    //var query =
        //    //    from artist in _context.Artists
        //    //    where artist.Name.Contains(textSearch.Text)
        //    //    orderby artist.Name
        //    //    select artist;

        //    //labelResults.Content = query.FirstOrDefault();
        //    //listArtistSearchResults.ItemsSource = query.ToList();
        //    var query =
        //        _context.Artists.Where(artist => artist.Name.Contains(textSearch.Text)).OrderBy(artist => artist.ArtistId).ToList();

        //    listArtistSearchResults.Items.Clear();
        //    foreach (var artist in query)
        //    {
        //        listArtistSearchResults.Items.Add(artist);
        //    }
        //}

        private void textSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Linq 
            //Defining out LINQ query
            var query =
                _context.Artists.Where(artist => artist.Name.Contains(textSearch.Text)).OrderBy(artist => artist.ArtistId).ToList();

            
            //Update the ItemsSource of the listbox to the new query results
            listArtistSearchResults.ItemsSource = query;
        }
    }
}

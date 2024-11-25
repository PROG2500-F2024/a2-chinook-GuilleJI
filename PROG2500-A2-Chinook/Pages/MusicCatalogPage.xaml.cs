using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
    /// Interaction logic for MusicCatalogPage.xaml
    /// </summary>
    public partial class MusicCatalogPage : Page
    {
        private readonly ChinookContext _context = new ChinookContext();
        private CollectionViewSource catalogsViewsource; 
        public MusicCatalogPage()
        {
            InitializeComponent();
            // Set the data context of the page to the ChinookContext
            catalogsViewsource = (CollectionViewSource)FindResource(nameof(catalogsViewsource));


            //Load data.. from BOTH sets
            _context.Artists.Load();
            _context.Albums.Load();

            // Set the source of the CollectionViewSource to the Artists in the ChinookContext
            catalogsViewsource.Source = _context.Artists.Local.ToObservableCollection();
        }

        private void textSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Define a grouping query to get grouped catalog data
            var query=
                from cat in _context.Artists
                where cat.Name.Contains(textSearch.Text)
                select cat;

            //Execute the query against the db and assign it as the data source for the ListView
            catalogsListView.ItemsSource = query.ToList();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PROG2500_A2_Chinook.Data;
using PROG2500_A2_Chinook.Models;
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
            _context.Artists.Include(a => a.Albums).Load();

            //Group artists by the first letter of their name 
            var query = 
                from artist in _context.Artists
                group artist by artist.Name.ToUpper().Substring(0, 1) into artistGroup
                select new
                {
                    Index = artistGroup.Key,
                    CatCount = artistGroup.Count(),
                    cat = artistGroup.ToList()
                };

            // Set the grouped data as the initial items source
            catalogsListView.ItemsSource = query.ToList();
        }

        private void textSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Filtering artists based on the search text
            var query =
               from artist in _context.Artists
               where artist.Name.Contains(textSearch.Text)
               group artist by artist.Name.ToUpper().Substring(0, 1) into artistGroup
               select new
               {
                   Index = artistGroup.Key,
                   CatCount = artistGroup.Count(),
                   cat = artistGroup.ToList()
               };

            // Update the ListView ItemsSource with the filtered data
            catalogsListView.ItemsSource = query.ToList();
            
        }
    }
}

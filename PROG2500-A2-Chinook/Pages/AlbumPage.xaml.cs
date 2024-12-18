﻿using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for AlbumPage.xaml
    /// </summary>
    public partial class AlbumPage : Page
    {
        private ChinookContext _context = new ChinookContext();
        CollectionViewSource albumsViewSource = new CollectionViewSource();
        public AlbumPage()
        {
            InitializeComponent();

            //Tie the markup viewsource object to the C# code viewsource object
            albumsViewSource = (CollectionViewSource)FindResource(nameof(albumsViewSource));

            //Use the dbContext to tell EntityFramework to load the data to use on this page
            _context.Albums.Load();

            //Set the viewsource data source to use the albums data collection (dbset)
            albumsViewSource.Source = _context.Albums.Local.ToObservableCollection();

            // Bind the initial list of albums to the listbox
            listAlbumSearchResults.ItemsSource = _context.Albums.Local.ToObservableCollection();
        }

        private void textSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Linq
            //Defining out LINQ query
            var query =
                _context.Albums.Where(album => album.Title.Contains(textSearch.Text)).OrderBy(album => album.AlbumId).ToList();

            //Update the listbox with the results of the query
            listAlbumSearchResults.ItemsSource = query;
        }
    }
}

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
    /// Interaction logic for GenrePage.xaml
    /// </summary>
    public partial class GenrePage : Page
    {
        ChinookContext context = new ChinookContext();
        CollectionViewSource genreViewSource = new CollectionViewSource();
        public GenrePage()
        {
            InitializeComponent();

            //Tie the markup viewsource object to the C# code viewsource object
            genreViewSource = (CollectionViewSource)FindResource(nameof(genreViewSource));

            //Use the dbContext to tell EntityFramework to load the data to use on this page
            context.Genres.Load();

            //Set the viewsource data source to use the genre data collection (dbset)
            genreViewSource.Source = context.Genres.Local.ToObservableCollection();
        }
    }
}

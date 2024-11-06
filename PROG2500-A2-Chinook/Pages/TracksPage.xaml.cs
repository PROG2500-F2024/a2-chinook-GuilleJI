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
    /// Interaction logic for TracksPage.xaml
    /// </summary>
    public partial class TracksPage : Page
    {
        //Create a new instance of the ChinookContext class 
        ChinookContext context = new ChinookContext();

        // Create a new instance of the CollectionViewSource class
        CollectionViewSource trackViewSource = new CollectionViewSource();
        public TracksPage()
        {
            InitializeComponent();

            //Tie the markup viewsource object to the C# code viewsource object 
            trackViewSource = (CollectionViewSource)FindResource(nameof(trackViewSource));

            //Use the dbContext to tell EntityFramework to load the data to use on this page 
            context.Tracks.Load();

            //Set the viewsource data source to use the tracks data collection (dbset) 
            trackViewSource.Source = context.Tracks.Local.ToObservableCollection();

        }
    }
}

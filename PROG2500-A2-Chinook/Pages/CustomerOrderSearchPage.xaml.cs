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
    /// Interaction logic for CustomerOrderSearchPage.xaml
    /// </summary>
    public partial class CustomerOrderSearchPage : Page
    {
        private ChinookContext _context = new ChinookContext();

        //Create a new instance of the CollectionViewSource class
        CollectionViewSource customerViewSource = new CollectionViewSource();
        public CustomerOrderSearchPage()
        {
            InitializeComponent();

            //tie the markup viewsource object to the C# code viewsource object
            //customerViewSource = (CollectionViewSource)FindResource(nameof(customerViewSource));

            //Use the dbContext to tell EntityFramework to load the data to use on this page
            _context.Customers.Include(a => a.Invoices).Load();

            var query =
                from customer in _context.Invoices
                group customer by customer.Customer.LastName;

            //Set the viewsource data source to use the customers data collection (dbset)
            //customerViewSource.Source = _context.Customers.Local.ToObservableCollection();

                //Bind the initial list of tracks to the listbox
            CustomerSearchResults.ItemsSource = _context.Customers.Local.ToObservableCollection();
        }

        private void textSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Linq
            //Defining  out LINQ query
            var query =
                  _context.Customers.Where(customer => customer.FirstName.Contains(textSearch.Text)).OrderBy(customer => customer.CustomerId).ToList();

            //Update the list of tracks in the listbox
            CustomerSearchResults.ItemsSource = query;
        }
    }
}


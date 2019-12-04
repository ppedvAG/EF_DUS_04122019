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

namespace HalloEF_DbFirst
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

        NorthwindEntities context = new NorthwindEntities();
        private void Laden(object sender, RoutedEventArgs e)
        {
            myGrid.ItemsSource = context.Employees.ToList();
        }

        private void Speichern(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }

        private void LadeStoreProc(object sender, RoutedEventArgs e)
        {
            myGrid.ItemsSource = context.Sales_by_Year(DateTime.Today.AddYears(-30), DateTime.Today);
        }

        PROGRAMMINGEFDB1Entities context2 = new PROGRAMMINGEFDB1Entities();
        private void LadenRGRGR(object sender, RoutedEventArgs e)
        {
            myGrid.ItemsSource = context2.GetContactsByState("Texas").ToList();
        }

        private void SpeichernGRRRR(object sender, RoutedEventArgs e)
        {
            context2.SaveChanges();
        }

        private void DeletePROGGG(object sender, RoutedEventArgs e)
        {
            if (myGrid.SelectedItem is Contact c)
                context2.Contacts.Remove(c);
        }
    }
}

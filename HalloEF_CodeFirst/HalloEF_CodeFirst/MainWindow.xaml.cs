using Bogus;
using HalloEF_CodeFirst.Data;
using HalloEF_CodeFirst.Model;
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

namespace HalloEF_CodeFirst
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

        EfContext context = new EfContext();

        private void Laden(object sender, RoutedEventArgs e)
        {
            myGrid.ItemsSource = context.Staende.ToList();
        }

        private void Demodaten(object sender, RoutedEventArgs e)
        {
            var faker = new Faker("de");
            var markt = new Markt()
            {
                Ort = faker.Address.City(),
                Von = DateTime.MinValue,
                Bis = DateTime.MaxValue
            };

            for (int i = 0; i < 100; i++)
            {
                var stand = new Stand()
                {
                    Besitzer = faker.Name.FullName(),
                    Typ = faker.Random.Enum<Standtyp>(),
                    Name = faker.Company.CompanyName()

                };
                stand.Maerkte.Add(markt);


                for (int j = 0; j < faker.Random.Int(3, 10); j++)
                {
                    var p = new Plunder()
                    {
                        Glaenzt = faker.Random.Bool(),
                        Material = faker.Commerce.ProductMaterial(),
                        Name = faker.Commerce.ProductName(),
                        Preis = faker.Random.Decimal(0.5m, 100),
                        Stand = stand
                    };
                    context.Plunder.Add(p);
                }
            }
            context.SaveChanges();
        }
    }
}

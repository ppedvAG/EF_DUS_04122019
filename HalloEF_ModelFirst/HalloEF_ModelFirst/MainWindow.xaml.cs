using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Data.Entity;

namespace HalloEF_ModelFirst
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

        Model1Container context = new Model1Container();

        private void Laden(object sender, RoutedEventArgs e)
        {
            //context = new Model1Container();

            var query = context.PersonSet
                               .OfType<Mitarbeiter>()
                               .Include(x => x.Kunde)
                               .Include(x => x.Abteilungen)
                               .Where(x => x.Name.StartsWith("F"))
                               .OrderBy(x => x.GebDatum.Month);
            query.Load();

            //MessageBox.Show(query.ToString());
            Debug.WriteLine(query.ToString());
            myGrid.ItemsSource = query.ToList();
        }



        private void Demo(object sender, RoutedEventArgs e)
        {
            var abt1 = new Abteilung() { Bezeichnung = "Holz" };
            var abt2 = new Abteilung() { Bezeichnung = "Steine" };

            for (int i = 0; i < 100; i++)
            {
                var m = new Mitarbeiter()
                {
                    Beruf = "Macht dinge",
                    GebDatum = DateTime.Today.AddYears(-100).AddDays(i * 7),
                    Name = $"Fred #{i:000}"
                };
                if (i % 2 == 0)
                    m.Abteilungen.Add(abt1);
                if (i % 3 == 0)
                    m.Abteilungen.Add(abt2);

                context.PersonSet.Add(m);
            }
            context.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EinenLaden(object sender, RoutedEventArgs e)
        {
            var m = context.PersonSet.OfType<Mitarbeiter>().FirstOrDefault(x => x.Id == 7);
            MessageBox.Show(m.Name);
        }
    }
}

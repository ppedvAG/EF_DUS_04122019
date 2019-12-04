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
                               .OrderBy(x => x.GebDatum.Month)
                               .Skip(20).Take(10);
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


        private void EinenLaden(object sender, RoutedEventArgs e)
        {
            var m = context.PersonSet.OfType<Mitarbeiter>().FirstOrDefault(x => x.Id == 7);
            m.GebDatum = m.GebDatum.AddDays(1);
            MessageBox.Show(m.Name);
        }

        private void Speichern(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }

        private void ShowState(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (myGrid.SelectedItem is Mitarbeiter m)
            {
                //MessageBox.Show(m.Name);
                context.Entry(m).State = EntityState.Modified;

                MessageBox.Show(context.Entry(m).State.ToString());
            }
        }

        private void Neu(object sender, RoutedEventArgs e)
        {
            var m = new Mitarbeiter() { Name = "FFFNEU" };
            context.PersonSet.Add(m);
        }

        private void Dlete(object sender, RoutedEventArgs e)
        {
            //var cmd =  context.Database.Connection.CreateCommand();
            //context.Database.Connection.Open();
            //cmd.CommandText = "SELECT COUNT(*) Person";
            //var cc = cmd.ExecuteScalar();
            //MessageBox.Show(cc.ToString());
            //context.Database.Connection.Close();

            if (myGrid.SelectedItem is Mitarbeiter m)
                context.PersonSet.Remove(m);
        }
    }
}


using ppedv.Hampelmann.Logic;
using ppedv.Hampelmann.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ppedv.Hampelmann.UI.WPF.ViewModels
{
    public class StandViewModel : INotifyPropertyChanged
    {
        Core core = new Core();
        private Stand selectedStand;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Stand> StandListe { get; set; }

        public Stand SelectedStand
        {
            get => selectedStand;
            set
            {
                selectedStand = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedStand"));
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand NewCommand { get; set; }

        public string CountStände { get => StandListe.Count().ToString(); }

        public StandViewModel()
        {
            StandListe = new ObservableCollection<Stand>(core.UnitOfWork.StandRepository.GetAll());

            SaveCommand = new RelayCommand(x => core.UnitOfWork.Save());
            NewCommand = new RelayCommand(UserWantsToAddNewStand);
        }

        private void UserWantsToAddNewStand(object obj)
        {
            var stand = new Stand() { Name = "NEU" };
            core.UnitOfWork.StandRepository.Add(stand);
            StandListe.Add(stand);
            SelectedStand = stand;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CountStände)));

        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meccanici.Model;
using Meccanici.DAL;
using System.ComponentModel;
using System.Windows.Input;
using Meccanici.Utility;

namespace Meccanici.ViewModel
{
    public class FixesViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Riparazione> fixes;

        public ObservableCollection<Riparazione> Fixes
        {
            get { return fixes; }
            set
            {
                fixes = value;
                OnPropertyChanged("Fixes");
            }
        }

        private Riparazione selectedFix;
        public Riparazione SelectedFix
        {
            get
            {
                return selectedFix;
            }
            set
            {
                selectedFix = value;
                OnPropertyChanged("SelectedFix");
                SelectedFixCar = Cars.Where(x => x.Targa == SelectedFix.CarID).FirstOrDefault();
                SelectedMechanic = Mechanics.Where(x => x.ID == SelectedFix.MechanicID).FirstOrDefault();
            }
        }

        public List<Person> Mechanics { get; set; }
        public List<Auto> Cars { get; set; }

        private Auto selectedFixCar;
        public Auto SelectedFixCar
        {
            get
            {
                return selectedFixCar;
            }
            set
            {
                selectedFixCar = value;
                OnPropertyChanged("SelectedFixCar");
            }
        }

        private Person selectedMechanic;
        public Person SelectedMechanic
        {
            get
            {
                return selectedMechanic;
            }
            set
            {
                selectedMechanic = value;
                OnPropertyChanged("SelectedMechanic");
                if (SelectedMechanic != null)
                SelectedFix.MechanicID = SelectedMechanic.ID;
            }
        }


        public ICommand AddFixCommand { get; set; }
        public ICommand SaveFixCommand { get; set; }

        

        public FixesViewModel()
        {
            Fixes = new ObservableCollection<Riparazione>(App.fixDataService.GetAllFixes());
            AddFixCommand = new CustomCommand(AddFix, delegate { return true; });
            SaveFixCommand = new CustomCommand(SaveFix, delegate { return SelectedFix != null; });
            Mechanics = App.mechanicDataService.GetAllMechanics();
            Cars = App.carDataService.GetAllCars();
        }

        void AddFix(object obj)
        {
            SelectedFix = new Riparazione();
        }
        void SaveFix(object obj)
        {
            if (SelectedFix.ID == 0)
                App.fixDataService.NewFix(SelectedFix);
            else
                App.fixDataService.UpdateFix(SelectedFix);
            Fixes = new ObservableCollection<Riparazione>(App.fixDataService.GetAllFixes());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}

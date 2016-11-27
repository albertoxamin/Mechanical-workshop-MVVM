using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meccanici.Model;
using System.ComponentModel;
using Meccanici.DAL;
using System.Windows.Input;
using Meccanici.Utility;

namespace Meccanici.ViewModels
{
    public class AutoViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Auto> cars;

        public ObservableCollection<Auto> Cars
        {
            get { return cars; }
            set
            {
                cars = value;
                OnPropertyChanged("Cars");
            }
        }

        private Auto selectedCar;

        public Auto SelectedCar
        {
            get { return selectedCar; }
            set
            {
                selectedCar = value;
                OnPropertyChanged("SelectedCar");
                SelectedCarCustomer = Clienti.Where(x=>x.ID==SelectedCar.ID_Cliente).FirstOrDefault();
                SelectedCarFixes = new ObservableCollection<Riparazione>(App.fixDataService.GetCarFixes(SelectedCar.Targa));
            }
        }

        private Cliente selectedCarCustomer;

        public Cliente SelectedCarCustomer
        {
            get { return selectedCarCustomer; }
            set
            {
                selectedCarCustomer = value;
                OnPropertyChanged("SelectedCarCustomer");
            }
        }

        public List<Cliente> Clienti
        {
            get;set;
        }

        private ObservableCollection<Riparazione> selectedCarFixes;

        public ObservableCollection<Riparazione> SelectedCarFixes
        {
            get { return selectedCarFixes; }
            set
            {
                selectedCarFixes = value;
                OnPropertyChanged("SelectedCarFixes");
            }
        }

        private bool isEditing;
        public bool IsEditing
        {
            get { return isEditing; }
            set
            {
                isEditing = value;
                OnPropertyChanged("IsEditing");
            }
        }

        public ICommand AddCarCommand { get; set; }
        public ICommand SaveCarCommand { get; set; }
        public ICommand DeleteCarCommand { get; set; }
        private void NewCar(object obj)
        {
            SelectedCar = new Auto();
            IsEditing = true;
        }

        private void SaveCar(object obj)
        {
            SelectedCar.EndEdit();
            IsEditing = false;
            if (!Cars.Contains(SelectedCar))
            {
                App.carDataService.NewCar(SelectedCar);
                Cars.Add(SelectedCar);
            }
        }

        public AutoViewModel()
        {
            Cars = new ObservableCollection<Auto>(App.carDataService.GetAllCars());
            AddCarCommand = new CustomCommand(NewCar, delegate { return true; });
            SaveCarCommand = new CustomCommand(SaveCar, delegate { return IsEditing; });
            Clienti = App.customerDataService.GetAllCustomers();
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

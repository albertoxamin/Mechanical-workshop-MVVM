using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meccanici.Model;
using System.ComponentModel;
using System.Windows.Input;
using Meccanici.Utility;
using Meccanici.Services;
using Meccanici.DAL;

namespace Meccanici.ViewModel
{
    public class ClientiViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Person> clienti;

        public ObservableCollection<Person> Customers
        {
            get { return clienti; }
            set
            {
                clienti = value;
                OnPropertyChanged("Customers");
            }
        }

        private ObservableCollection<Person> filteredCustomers;
        public ObservableCollection<Person> FilteredCustomers
        {
            get { return filteredCustomers ?? Customers; }
            set
            {
                filteredCustomers = value;
                SelectedCustomer = filteredCustomers.FirstOrDefault();
                OnPropertyChanged("FilteredCustomers");
            }
        }

        private Person selectedCustomer;
        public Person SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                selectedCustomer = value;
                if (value != null)
                    SelectedCustomerCars = App.carDataService.GetCustomerCars(SelectedCustomer.ID);
                else
                    SelectedCustomerCars = null;
                IsEditing = false;
                OnPropertyChanged("SelectedCustomer");
            }
        }

        private List<Auto> selectedCustomerCars;

        public List<Auto> SelectedCustomerCars
        {
            get
            {
                return selectedCustomerCars;
            }
            set
            {
                selectedCustomerCars = value;
                OnPropertyChanged("SelectedCustomerCars");
            }
        }

        public Action editingAnimation;

        private bool isEditing;
        public bool IsEditing
        {
            get { return isEditing; }
            set
            {
                isEditing = value;
                if (IsEditing)
                    CurrentEditIcon = "";
                else
                    CurrentEditIcon = "";
                OnPropertyChanged("IsEditing");
                editingAnimation.Invoke();
            }
        }

        public ICommand AddCustomerCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private string currentEditIcon = "";
        public string CurrentEditIcon
        {
            get { return currentEditIcon; }
            set
            {
                currentEditIcon = value;
                OnPropertyChanged("CurrentEditIcon");
            }
        }

        private void EditCustomer(object obj)
        {
            IsEditing = !IsEditing;
            if (!IsEditing)
                SelectedCustomer.CancelEdit();
            else
                SelectedCustomer.BeginEdit();
        }

        private void SaveCustomer(object obj)
        {
            SelectedCustomer.EndEdit();
            IsEditing = false;
            if (!Customers.Contains(SelectedCustomer))
            {
                App.customerDataService.NewCustomer(SelectedCustomer);
                Customers.Add(SelectedCustomer);
            }
        }

        private void NewCustomer(object obj)
        {
            SelectedCustomer = new Person();
            IsEditing = true;
        }

        private void DeleteCustomer(object obj)
        {
            App.customerDataService.DeleteCustomer(SelectedCustomer);
            Customers.Remove(SelectedCustomer);
            //SelectedCustomer = Clienti.FirstOrDefault();
            IsEditing = false;
        }

        private bool CanEditCustomer(object obj)
        {
            return SelectedCustomer != null;
        }

        private bool CanSaveCustomer(object obj)
        {
            return IsEditing;
            
        }

        private bool CanDeleteCustomer(object obj)
        {
            return Customers.Contains(SelectedCustomer) && IsEditing;
        }

        private string searchString;
        public string SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value.ToLower();
                FilteredCustomers = new ObservableCollection<Person>(Customers.Where(x =>
                x.Name.ToLower().Contains(SearchString) ||
                x.Surname.ToLower().Contains(SearchString) ));
                OnPropertyChanged("SearchString");
            }
        }

        private void LoadCommands()
        {
            EditCommand = new CustomCommand(EditCustomer, CanEditCustomer);
            SaveCommand = new CustomCommand(SaveCustomer, CanSaveCustomer);
            DeleteCommand = new CustomCommand(DeleteCustomer, CanDeleteCustomer);
            AddCustomerCommand = new CustomCommand(NewCustomer, delegate { return true; });
        }

        public ClientiViewModel(RepositoryType v)
        {
            if (v == RepositoryType.Customers)
                Customers = new ObservableCollection<Person>(App.customerDataService.GetAllCustomers());
            else
                Customers = new ObservableCollection<Person>(App.mechanicDataService.GetAllMechanics());
            CurrentRepo = v;
            LoadCommands();
        }
        public enum RepositoryType
        {
            Customers, Employees 
        }
        public RepositoryType CurrentRepo { get; set; }

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

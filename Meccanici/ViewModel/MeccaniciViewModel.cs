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
using Meccanici.DAL;

namespace Meccanici.ViewModel
{
    public class MeccaniciViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Meccanico> mechanics;

        public ObservableCollection<Meccanico> Mechanics
        {
            get { return mechanics; }
            set
            {
                mechanics = value;
                OnPropertyChanged("Mechanics");
            }
        }

        private Meccanico selectedMechanic;
        public  Meccanico SelectedMechanic
        {
            get { return selectedMechanic; }
            set
            {
                //if (IsEditing)
                selectedMechanic = value;
                OnPropertyChanged("SelectedMechanic");
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

        public ICommand EditCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private string currentEditIcon = "";
        public string CurrentEditIcon {
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
                SelectedMechanic.CancelEdit();
            else
                SelectedMechanic.BeginEdit();
        }

        private void SaveCustomer(object obj)
        {
            SelectedMechanic.EndEdit();
            IsEditing = false;
        }

        private void DeleteCustomer(object obj)
        {
            //TODO
        }

        private bool CanEditCustomer(object obj)
        {
            return true;
        }

        private bool CanSaveCustomer(object obj)
        {
            return IsEditing;
        }

        private void LoadCommands()
        {
            EditCommand = new CustomCommand(EditCustomer, CanEditCustomer);
            SaveCommand = new CustomCommand(SaveCustomer, CanSaveCustomer);
            DeleteCommand = new CustomCommand(DeleteCustomer, CanSaveCustomer);
        }

        public MeccaniciViewModel()
        {
            Mechanics = new ObservableCollection<Meccanico>(App.mechanicDataService.GetAllMechanics());
            LoadCommands();
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meccanici.Model
{
    public class Cliente : INotifyPropertyChanged, IEditableObject
    {
        struct CustomerData
        {
            internal int id;
            internal string name;
            internal string surname;
        }

        private CustomerData customerData;

        public int ID
        {
            get { return customerData.id; }
            set
            {
                customerData.id = value;
            }
        }

        public string Name
        {
            get
            {
                return customerData.name;
            }
            set
            {
                customerData.name = value;
                OnPropertyChanged("Name");
                OnPropertyChanged("Initials");
            }
        }

        public string Surname
        {
            get
            {
                return customerData.surname;
            }
            set
            {
                customerData.surname = value;
                OnPropertyChanged("Surname");
                OnPropertyChanged("Initials");
            }
        }

        public string Initials
        {
            get
            {
                return string.Format("{0}{1}", Name[0], Surname[0]);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private CustomerData backupData;
        private bool isEditing;

        public void BeginEdit()
        {
            if (!isEditing)
            {
                isEditing = true;
                backupData = customerData;
                Console.WriteLine("Started Editing Customer ({0} {1}) with ID {0}", Name, Surname, ID);
            }
        }

        public void CancelEdit()
        {
            if (isEditing)
            {
                customerData = backupData;
                OnPropertyChanged("Name");
                OnPropertyChanged("Surname");
                OnPropertyChanged("Initials");
                isEditing = false;
                Console.WriteLine("Cancelled Editing Customer ({0} {1}) with ID {0}", Name, Surname, ID);
            }
        }

        public void EndEdit()
        {
            if (isEditing)
            {
                backupData = customerData;
                isEditing = false;
                Console.WriteLine("Ended Editing Customer ({0} {1}) with ID {0}", Name, Surname, ID);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Name, Surname);
        }
    }
}

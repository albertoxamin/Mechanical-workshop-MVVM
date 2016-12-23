using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meccanici.Model
{
    public class Person : INotifyPropertyChanged, IEditableObject
    {
        struct PersonData
        {
            internal int id;
            internal string name;
            internal string surname;
            internal string email;
            internal string phone;
            internal byte isMechanic;
        }

        private PersonData personData;

        public int ID
        {
            get { return personData.id; }
            set
            {
                personData.id = value;
            }
        }

        public string Name
        {
            get
            {
                return personData.name;
            }
            set
            {
                personData.name = value;
                OnPropertyChanged("Name");
                OnPropertyChanged("Initials");
            }
        }

        public string Surname
        {
            get
            {
                return personData.surname;
            }
            set
            {
                personData.surname = value;
                OnPropertyChanged("Surname");
                OnPropertyChanged("Initials");
            }
        }

        public string Email
        {
            get
            {
                return personData.email;
            }
            set
            {
                personData.email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Phone
        {
            get
            {
                return personData.phone;
            }
            set
            {
                personData.phone = value;
                OnPropertyChanged("Email");
            }
        }

        public byte IsMechanic
        {
            get
            {
                return personData.isMechanic;
            }
            set
            {
                personData.isMechanic = value;
                OnPropertyChanged("IsMechanic");
            }
        }

        public string Initials
        {
            get
            {
                try
                {
                    return string.Format("{0}{1}", Name[0], Surname[0]);
                }
                catch
                {
                    return "";
                }
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

        private PersonData backupData;
        private bool isEditing;

        public void BeginEdit()
        {
            if (!isEditing)
            {
                isEditing = true;
                backupData = personData;
                Console.WriteLine("Started Editing Customer ({0} {1}) with ID {2}", Name, Surname, ID);
            }
        }

        public void CancelEdit()
        {
            if (isEditing)
            {
                personData = backupData;
                OnPropertyChanged("Name");
                OnPropertyChanged("Surname");
                OnPropertyChanged("Initials");
                isEditing = false;
                Console.WriteLine("Cancelled Editing Customer ({0} {1}) with ID {2}", Name, Surname, ID);
            }
        }

        public void EndEdit()
        {
            if (isEditing)
            {
                backupData = personData;
                isEditing = false;
                Console.WriteLine("Ended Editing Customer ({0} {1}) with ID {2}", Name, Surname, ID);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Name, Surname);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meccanici.Model
{
    public class Riparazione : INotifyPropertyChanged
    {
        private int id;
        private int mechanicID;
        private string carID;
        private int customerID;
        private string note;
        private DateTime date;

        public Riparazione()
        {
            date = DateTime.Today;
        }

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        public int MechanicID
        {
            get { return mechanicID; }
            set
            {
                mechanicID = value;
                OnPropertyChanged("MechanicID");
            }
        }

        public string CarID
        {
            get { return carID; }
            set
            {
                carID = value;
                OnPropertyChanged("CarID");
            }
        }

        public int CustomerID
        {
            get { return customerID; }
            set
            {
                customerID = value;
                OnPropertyChanged("CustomerID");
            }
        }

        public string Note
        {
            get { return note; }
            set
            {
                note = value;
                OnPropertyChanged("Note");
            }
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
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
    }
}

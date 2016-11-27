﻿using System;
using System.ComponentModel;

namespace Meccanici.Model
{
    public class Auto : INotifyPropertyChanged, IEditableObject
    {
        struct CarData
        {
            internal int id;
            internal string marca;
            internal string modello;
            internal string targa;
            internal int anno;
            internal int id_Cliente;
        }

        private CarData carData;
        private CarData backupData;

        public string Marca
        {
            get { return carData.marca; }
            set
            {
                carData.marca = value;
                OnPropertyChanged("Marca");
            }
        }

        public string Modello
        {
            get { return carData.modello; }
            set
            {
                carData.modello = value;
                OnPropertyChanged("Modello");
            }
        }

        public string Targa
        {
            get { return carData.targa; }
            set
            {
                carData.targa = value;
                OnPropertyChanged("Targa");
            }
        }

        public int Anno
        {
            get { return carData.anno; }
            set
            {
                carData.anno = value;
                OnPropertyChanged("Anno");
            }
        }

        public int ID_Cliente
        {
            get { return carData.id_Cliente; }
            set
            {
                carData.id_Cliente = value;
                OnPropertyChanged("ID_Cliente");
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

        public void BeginEdit()
        {
            throw new NotImplementedException();
        }

        public void EndEdit()
        {
            throw new NotImplementedException();
        }

        public void CancelEdit()
        {
            throw new NotImplementedException();
        }
    }
}
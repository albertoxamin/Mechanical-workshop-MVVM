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
            }
        }

        public ICommand AddFixCommand { get; set; }

        public FixesViewModel()
        {
            Fixes = new ObservableCollection<Riparazione>(App.fixDataService.GetAllFixes());
            AddFixCommand = new CustomCommand(null, delegate { return true; });
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

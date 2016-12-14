using Meccanici.DAL;
using Meccanici.Services;
using Meccanici.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meccanici
{
    public class ViewModelLocator
    {
        private static HomeViewModel homeViewModel = new HomeViewModel();
        private static ClientiViewModel clientiViewModel = new ClientiViewModel();
        private static ClientiViewModel meccaniciViewModel = new ClientiViewModel(true);
        private static AutoViewModel autoViewModel = new AutoViewModel();
        private static FixesViewModel fixesViewModel = new FixesViewModel();

        public static HomeViewModel HomeViewModel
        {
            get
            {
                return homeViewModel;
            }
        }

        public static ClientiViewModel ClientiViewModel
        {
            get
            {
                return clientiViewModel;
            }
        }

        public static AutoViewModel AutoViewModel
        {
            get
            {
                return autoViewModel;
            }
        }

        public static ClientiViewModel MeccaniciViewModel
        {
            get
            {
                return meccaniciViewModel;
            }
        }
        public static FixesViewModel FixesViewModel
        {
            get
            {
                return fixesViewModel;
            }
        }
    }
}

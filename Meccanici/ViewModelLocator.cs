using Meccanici.DAL;
using Meccanici.Services;
using Meccanici.ViewModels;
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
        private static MeccaniciViewModel meccaniciViewModel = new MeccaniciViewModel();
        private static AutoViewModel autoViewModel = new AutoViewModel();

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

        public static MeccaniciViewModel MeccaniciViewModel
        {
            get
            {
                return meccaniciViewModel;
            }
        }
    }
}

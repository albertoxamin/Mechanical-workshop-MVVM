using Meccanici.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Meccanici
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        DBConnection dbConnection = new DBConnection();
        public static ICustomerRepository customerDataService = new CustomerRepository();
        public static ICarRepository carDataService = new CarRepository();
        public static IMechanicRepository mechanicDataService = new MechanicRepository();
        public static IFixRepository fixDataService = new FixRepository();
    }
}

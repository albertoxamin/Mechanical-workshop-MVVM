using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meccanici.Model;

namespace Meccanici.Services
{
    public interface ICustomerDataService
    {
        void DeleteCustomer(Person customer);
        List<Person> GetAllCustomers();
        Person GetCustomerDetail(int customerID);
        void UpdateCustomer(Person customer);
    }
}

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
        void DeleteCustomer(Cliente customer);
        List<Cliente> GetAllCustomers();
        Cliente GetCustomerDetail(int customerID);
        void UpdateCustomer(Cliente customer);
    }
}

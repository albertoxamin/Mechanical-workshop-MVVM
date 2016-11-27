using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meccanici.Model;

namespace Meccanici.DAL
{
    public interface ICustomerRepository
    {
        void DeleteCustomer(Cliente customer);
        List<Cliente> GetAllCustomers();
        Cliente GetCustomerDetail(int customerID);
        void UpdateCustomer(Cliente customer);
        void NewCustomer(Cliente customer);
    }
}

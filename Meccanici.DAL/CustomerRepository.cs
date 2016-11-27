using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meccanici.Model;

namespace Meccanici.DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        private static List<Cliente> customers;

        public void DeleteCustomer(Cliente customer)
        {
            customers.Remove(customer);
        }

        public List<Cliente> GetAllCustomers()
        {
            if (customers == null)
                LoadCustomers();
            return customers;
        }

        public Cliente GetCustomerDetail(int customerID)
        {
            if (customers == null)
                LoadCustomers();
            return customers.Where(x => x.ID == customerID).FirstOrDefault();
        }

        public void NewCustomer(Cliente customer)
        {
            customers.Add(customer);
        }

        public void UpdateCustomer(Cliente customer)
        {
            Cliente customerToUpdate = customers.Where(x => x.ID == customer.ID).FirstOrDefault();
            customerToUpdate = customer;
        }

        private void LoadCustomers()
        {
            customers = new List<Cliente>()
            {
                new Cliente() { ID = 1, Name = "Gino", Surname = "Fantozzi" },
                new Cliente() { ID = 2, Name = "Elio", Surname = "Teso" },
                new Cliente() { ID = 3, Name = "Giovanni", Surname = "Murica" },
                new Cliente() { ID = 4, Name = "Walter", Surname = "White" },
                new Cliente() { ID = 5, Name = "Heisenberg", Surname = "Chef" }
            };
        }
    }
}

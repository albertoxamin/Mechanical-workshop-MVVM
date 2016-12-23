using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meccanici.Model;

namespace Meccanici.DAL
{
    public interface IMechanicRepository
    {
        void DeleteMechanic(Person mechanic);
        List<Person> GetAllMechanics();
        Person GetMechanicDetail(int mechanicID);
        void UpdateMechanic(Person mechanic);
        void NewEmployee(Person selectedCustomer);
    }
}

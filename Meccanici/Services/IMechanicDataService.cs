using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meccanici.Model;

namespace Meccanici.Services
{
    public interface IMechanicDataService
    {
        void DeleteMechanic(Person customer);
        List<Person> GetAllMechanics();
        Person GetMechanicDetail(int customerID);
        void UpdateMechanic(Person customer);
    }
}

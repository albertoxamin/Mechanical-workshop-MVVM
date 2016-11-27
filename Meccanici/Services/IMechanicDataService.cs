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
        void DeleteMechanic(Meccanico customer);
        List<Meccanico> GetAllMechanics();
        Meccanico GetMechanicDetail(int customerID);
        void UpdateMechanic(Meccanico customer);
    }
}

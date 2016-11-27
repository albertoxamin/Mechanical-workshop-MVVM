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
        void DeleteMechanic(Meccanico mechanic);
        List<Meccanico> GetAllMechanics();
        Meccanico GetMechanicDetail(int mechanicID);
        void UpdateMechanic(Meccanico mechanic);
    }
}

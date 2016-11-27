using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meccanici.Model;

namespace Meccanici.DAL
{
    public class MechanicRepository : IMechanicRepository
    {
        private List<Meccanico> mechanics;
        public void DeleteMechanic(Meccanico mechanic)
        {
            mechanics.Remove(mechanic);
        }

        public List<Meccanico> GetAllMechanics()
        {
            if (mechanics == null)
                LoadMechanics();
            return mechanics;
        }

        public Meccanico GetMechanicDetail(int mechanicID)
        {
            if (mechanics == null)
                LoadMechanics();
            return mechanics.Where(x=>x.ID == mechanicID).FirstOrDefault();
        }

        public void UpdateMechanic(Meccanico mechanic)
        {
            Meccanico mechanicToUpdate = mechanics.Where(x => x.ID == mechanic.ID).FirstOrDefault();
            mechanicToUpdate = mechanic;
        }

        void LoadMechanics()
        {
            mechanics = new List<Meccanico>()
            {
                new Meccanico() { ID=1, Name = "Horacio", Surname = "Pagani" },
                new Meccanico() { ID = 2, Name = "Enzo", Surname = "Ferrari" }
            };
        }
    }
}

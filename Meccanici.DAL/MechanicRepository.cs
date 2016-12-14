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
        private List<Person> mechanics;
        public void DeleteMechanic(Person mechanic)
        {
            mechanics.Remove(mechanic);
        }

        public List<Person> GetAllMechanics()
        {
            if (mechanics == null)
                LoadMechanics();
            return mechanics;
        }

        public Person GetMechanicDetail(int mechanicID)
        {
            if (mechanics == null)
                LoadMechanics();
            return mechanics.Where(x=>x.ID == mechanicID).FirstOrDefault();
        }

        public void UpdateMechanic(Person mechanic)
        {
            Person mechanicToUpdate = mechanics.Where(x => x.ID == mechanic.ID).FirstOrDefault();
            mechanicToUpdate = mechanic;
        }

        void LoadMechanics()
        {
            mechanics = new List<Person>()
            {
                new Person() { ID=1, Name = "Horacio", Surname = "Pagani" },
                new Person() { ID = 2, Name = "Enzo", Surname = "Ferrari" }
            };
        }
    }
}

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

        public void NewEmployee(Person customer)
        {
            string values = "'" + customer.Name + "','" + customer.Surname + "','" + customer.Email + "','" + customer.Phone + "',1";
            DBConnection.instance.InsertInto(TABLE_NAME, "Name,Surname,Email,Phone,IsMechanic", values);
            mechanics.Add(customer);
        }

        private const string TABLE_NAME = "person";

        void LoadMechanics()
        {
            //mechanics = new List<Person>()
            //{
            //    new Person() { ID=1, Name = "Horacio", Surname = "Pagani" },
            //    new Person() { ID = 2, Name = "Enzo", Surname = "Ferrari" }
            //};
            mechanics = new List<Person>();
            var res = DBConnection.instance.ExecuteQuery(string.Format("SELECT * FROM {0} WHERE IsMechanic=1", TABLE_NAME)).Result;
            while (res.Read())
            {
                mechanics.Add(new Person()
                {
                    ID = (int)res["PersonID"],
                    Name = (string)res["Name"],
                    Surname = (string)res["Surname"],
                    Email = (string)res["Email"],
                    Phone = (string)res["Phone"]
                });
            }
            res.Close();
        }
    }
}

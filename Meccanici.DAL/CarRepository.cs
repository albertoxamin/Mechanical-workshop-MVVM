using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meccanici.Model;

namespace Meccanici.DAL
{
    public class CarRepository : ICarRepository
    {
        private List<Auto> cars;

        public void DeleteCar(Auto car)
        {
            cars.Remove(car);
        }

        public List<Auto> GetAllCars()
        {
            if (cars == null)
                LoadCars();
            return cars;
        }

        public Auto GetCarDetail(string carID)
        {
            if (cars == null)
                LoadCars();
            return cars.Where(x=>x.Targa == carID).FirstOrDefault();
        }

        public List<Auto> GetCustomerCars(int custID)
        {
            if (cars == null)
                LoadCars();
            return cars.Where(x => x.ID_Cliente == custID).ToList();
        }

        public void NewCar(Auto car)
        {
            if (car != null && cars != null)
            {
                string values = "'" + car.Marca + "','" + car.Modello + "'," + car.Anno + ",'" + car.Targa + "'," + car.ID_Cliente;
                DBConnection.instance.InsertInto(TABLE_NAME, "Marca,Modello,Anno,PlateCode,Owner_ID", values);
                cars.Add(car);
            }
        }

        public void UpdateCar(Auto car)
        {
            Auto carToUpdate = cars.Where(x => x.Targa == car.Targa).FirstOrDefault();
            carToUpdate = car;
        }

        private const string TABLE_NAME = "car";

        private async void LoadCars()
        {
            cars = new List<Auto>();
            var res = DBConnection.instance.ExecuteQuery("SELECT * FROM " + TABLE_NAME).Result;
            while (res.Read())
            {
                cars.Add(new Auto()
                {
                    Marca = (string)res["Marca"],
                    Modello = (string)res["Modello"],
                    Anno = (int)res["Anno"],
                    Targa = (string)res["PlateCode"],
                    ID_Cliente = (int)res["Owner_ID"]
                });
            }
            res.Close();
        }
    }
}

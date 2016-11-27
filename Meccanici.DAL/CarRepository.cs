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

        public void UpdateCar(Auto car)
        {
            Auto carToUpdate = cars.Where(x => x.Targa == car.Targa).FirstOrDefault();
            carToUpdate = car;
        }

        private void LoadCars()
        {
            cars = new List<Auto>()
            {
                new Auto() { Marca = "Nissan", Modello = "Juke", Anno = 2010, Targa = "FI007NE", ID_Cliente = 1 },
                new Auto() { Marca = "Mercedes", Modello = "Berlina", Anno = 2012, Targa = "FI001NE", ID_Cliente = 2 },
                new Auto() { Marca = "Pagani", Modello = "Huayra", Anno = 2011, Targa = "EK650VV", ID_Cliente = 3 },
                new Auto() { Marca = "Porsche", Modello = "911 Turbo S", Anno = 2007, Targa = "FI001GE", ID_Cliente = 4 },
                new Auto() { Marca = "Bugatti", Modello = "Chiron", Anno = 2016, Targa = "FI001GE", ID_Cliente = 5 }
            };
        }
    }
}

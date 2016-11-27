using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meccanici.Model;

namespace Meccanici.DAL
{
    public interface ICarRepository
    {
        void DeleteCar(Auto car);
        List<Auto> GetAllCars();
        List<Auto> GetCustomerCars(int custID);
        Auto GetCarDetail(string carID);
        void UpdateCar(Auto car);
        void NewCar(Auto car);
    }
}

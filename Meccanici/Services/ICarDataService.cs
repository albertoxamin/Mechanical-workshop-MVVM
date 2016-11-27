using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meccanici.Model;

namespace Meccanici.Services
{
    public interface ICarDataService
    {
        void DeleteCar(Auto customer);
        List<Auto> GetAllCars();
        Auto GetCarDetail(int customerID);
        void UpdateCar(Auto customer);
    }
}

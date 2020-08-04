using System;
using System.Collections.Generic;
using System.Text;
using CarDealershipDomain;

namespace CarDealershipRepository.Interfaces
{
    public interface ICarRepository
    {
        int Count();

        List<Car> List(bool sold);

        bool Add(Car car);

        void Sell(Car car, Client client);

        Car GetCarByNumber(string carNumber);
    }
}

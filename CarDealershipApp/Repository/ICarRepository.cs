using CarDealershipDomain;
using CarDealershipDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipApp.Repository
{
    public interface ICarRepository
    {
        int Count();

        LinkedList<Car> List(bool sold);

        bool Add(Car car);

        void Sell(Car car, Client client);

        Car GetCarByNumber(string carNumber);
    }
}

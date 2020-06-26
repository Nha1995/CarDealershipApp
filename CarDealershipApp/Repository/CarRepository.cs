using CarDealershipApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipApp.Repository
{
    public class CarRepository
    {
        private LinkedList<Car> _cars;

        public CarRepository()
        {
            _cars = new LinkedList<Car>();
        }

        public int Count()
        {
            return _cars.Count;
        }

        public LinkedList<Car> List()
        {
            return _cars;
        }

        public bool Add(Car car)
        {
            _cars.AddLast(car);
            return true;
        }

        public bool Sell(string number)
        {
            return true;
        }
    }
}

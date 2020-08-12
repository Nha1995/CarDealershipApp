using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using CarDealershipDomain;
using CarDealershipRepository.Interfaces;

namespace CarDealershipRepository.InMemory
{
    public class CarMemoryRepository : ICarRepository
    {
        private static long CurrentID = 0;
        private readonly LinkedList<Car> _cars;

        public CarMemoryRepository()
        {
            _cars = new LinkedList<Car>();
        }

        public int Count()
        {
            return _cars.Count;
        }

        public List<Car> List(bool sold)
        {
                List<Car> cars = new List<Car>();
                foreach (Car car in _cars)
                {
                    if (car.Sold == sold)
                    {
                        cars.Add(car);
                    }
                }
                return cars;
        }

        public bool Add(Car car)
        {
            car.Id = ++CurrentID;
            _cars.AddLast(car);
            LinkedListNode<Car> node;
            for (node = _cars.First; node != _cars.Last; node = node.Next)
            {
                if (_cars.Last.Value.Number == node.Value.Number)
                {
                    _cars.RemoveLast();
                    return false;
                }
            }
            return true;
        }

        public void Sell(Car car, Client client)
        {
            client.Cars.Add(car);
            car.Client = client;
            car.Sold = true;
        }

        public Car GetCarByNumber(string carNumber)
        {
            foreach (Car car in _cars)
            {
                if (car.Number == carNumber)
                {
                    return car;
                }
            }
            return null;
        }
    }
}
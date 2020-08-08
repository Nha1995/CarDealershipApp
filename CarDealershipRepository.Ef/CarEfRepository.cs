using CarDealershipDomain;
using CarDealershipRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipRepository.Ef
{
    public class CarEfRepository : EfRepository, ICarRepository
    {
        public CarEfRepository(CarDealershipDbContext dbContext) : base(dbContext) { }

        public bool Add(Car car)
        {
            var existingCar = _dbContext.Cars.FirstOrDefault(c => c.Number == car.Number);

            if (existingCar != null)
            {
                return false;
            }

            _dbContext.Cars.Add(car);
            _dbContext.SaveChanges();

            return true;
        }

        public int Count()
        {
            return _dbContext.Cars.Count();
        }

        public Car GetCarByNumber(string carNumber)
        {
            var car = _dbContext.Cars.FirstOrDefault(c => c.Number == carNumber);
            return car;
        }

        public List<Car> List(bool sold)
        {
            List<Car> cars = _dbContext.Cars
                .Include(c => c.Client)
                .Where(c => c.Sold == sold)
                .ToList();

            return cars;
        }

        public void Sell(Car car, Client client)
        {
            car.ClientId = client.Id;
            car.Sold = true;
            _dbContext.Cars.Update(car);
            _dbContext.SaveChanges();
        }
    }
}
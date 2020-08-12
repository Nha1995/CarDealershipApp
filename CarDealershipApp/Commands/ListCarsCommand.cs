using CarDealershipDomain;
using CarDealershipRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipCommands
{
    public class ListCarsCommand : CarCommand
    {
        public ListCarsCommand(ICarRepository carRepository) : base(carRepository) { }

        public override string CommandText()
        {
            return "list cars";
        }

        public override CommandResult Execute()
        {
            bool sold = false;
            Console.WriteLine();
            var cars = _carRepository.List(sold);
            foreach (Car car in cars)
            {
                    Console.WriteLine($"ID: {car.Id} Number: {car.Number} Model: {car.Model} Year: {car.Year} Color: {car.Color} Price: {car.Price}");
                    Console.WriteLine("______________________________________________________________");
            }
            if (cars.Count == 0)
            {
                return new CommandResult(false, "You have no cars");
            }
            if (cars.Count > 1)
            {
                return new CommandResult(true, $"Listed {cars.Count} cars");
            }
            else
            {
                return new CommandResult(true, $"{cars.Count} car is listed");
            }
        }
    }
}
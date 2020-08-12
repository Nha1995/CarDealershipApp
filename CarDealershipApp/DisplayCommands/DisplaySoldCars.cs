using CarDealershipCommands;
using CarDealershipDomain;
using CarDealershipRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipApp.DisplayCommands
{
    public class DisplaySoldCars : CarCommand
    {
        public DisplaySoldCars(ICarRepository carRepository) : base(carRepository) { }
        public override string CommandText()
        {
            return "display sold cars";
        }

        public override CommandResult Execute()
        {
            bool sold = true;
            Console.WriteLine();
            var cars = _carRepository.List(sold);

            foreach (Car car in cars)
            {
                if (car.Client != null)
                {
                    Console.WriteLine($"Car Id: {car.Id}, Number: {car.Number}, Model: {car.Model}, Year: {car.Year}, Color: {car.Color}, Price: {car.Price}");
                    Console.WriteLine($"Client Id: {car.Client.Id}, Client: {car.Client.Surname} {car.Client.Name}, Passport Id: {car.Client.PassportId}");
                }
                Console.WriteLine("______________________________________________________________");
            }
            if (cars.Count > 1)
            {
                return new CommandResult(true, $"Listed {cars.Count} cars");
            }
            if(cars.Count == 1)
            {
                return new CommandResult(true, $"{cars.Count} car is listed");
            }
            return new CommandResult(false, "You have no cars.");
        }
    }
}

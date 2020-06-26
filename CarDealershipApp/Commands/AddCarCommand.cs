using CarDealershipApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using CarDealershipApp.Domain;

namespace CarDealershipApp.Commands
{
    public class AddCarCommand : CarCommand
    {
        public AddCarCommand(CarRepository carRepository) : base(carRepository) { }

        public override string CommandText()
        {
            return "add car";
        }

        public override CommandResult Execute()
        {
            Console.WriteLine("Car number: ");
            string number = Console.ReadLine();
            Car car = new Car(number);
            bool success = _carRepository.Add(car);
            string message = "Car added successfully";
            if (!success)
            {
                message = $"Car with number {number} already exists";
            }
            return new CommandResult(success, message);
        }
    }
}

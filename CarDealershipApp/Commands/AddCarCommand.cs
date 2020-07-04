using CarDealershipApp.Domain;
using CarDealershipApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

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
            Console.WriteLine("Please, write car number:");
            string number = Console.ReadLine();
            Console.WriteLine("Model:");
            string model = Console.ReadLine();
            Console.WriteLine("Year making:");
            string YearMaking = Console.ReadLine();
            Console.WriteLine("Color:");
            string Color = Console.ReadLine();
            Console.WriteLine("Price");
            int Price = int.Parse(Console.ReadLine());
            Car car = new Car(number, model, YearMaking, Color, Price);
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
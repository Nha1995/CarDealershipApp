using CarDealershipApp.Domain;
using CarDealershipApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipApp.Commands
{
    public class ListCarsCommand : CarCommand
    {
        public ListCarsCommand(CarRepository carRepository) : base(carRepository) { }

        public override string CommandText()
        {
            return "list cars";
        }

        public override CommandResult Execute()
        {
            int k=0;
            Console.WriteLine();
            foreach (Car car in _carRepository.List())
            {
                if (car.Client == null)
                {
                    Console.WriteLine($"ID: {car.Id} Number: {car.Number} Model: {car.Model} Year: {car.YearMaking} Color: {car.Color} Price: {car.Price}");
                    Console.WriteLine("______________________________________________________________");
                    ++k;
                }
            }
            if (k == 0)
            {
                return new CommandResult(false, "You have no cars");
            }
            if (k > 1)
            {
                return new CommandResult(true, $"Listed {k} cars");
            }
            else
            {
                return new CommandResult(true, $"{k} car is listed");
            }
        }
    }
}

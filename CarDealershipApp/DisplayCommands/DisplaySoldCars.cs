﻿using CarDealershipApp.Commands;
using CarDealershipApp.Domain;
using CarDealershipApp.Repository;
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
            Console.WriteLine();

            foreach (Car car in _carRepository.List())
            {
                if (car.Client != null)
                {
                    Console.WriteLine($"ID: {car.Id} Number: {car.Number} Model: {car.Model} Year: {car.YearMaking} Color: {car.Color} Price: {car.Price}");
                    Console.WriteLine($"Client: {car.Client.Surname} {car.Client.Name} Passport Id: {car.Client.PassportId}");
                }
                Console.WriteLine("______________________________________________________________");
            }
            if (_carRepository.Count() > 1)
            {
                return new CommandResult(true, $"Listed {_carRepository.Count()} cars");
            }
            if(_carRepository.Count()==1)
            {
                return new CommandResult(true, $"{_carRepository.Count()} car is listed");
            }
            return new CommandResult(false, "You have no cars.");
        }
    }
}

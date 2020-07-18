using CarDealershipRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipCommands
{
    public abstract class CarCommand : Command
    {
        protected ICarRepository _carRepository;
        public CarCommand(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
    }
}

using CarDealershipApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipApp.Commands
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

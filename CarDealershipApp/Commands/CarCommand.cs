using CarDealershipApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipApp.Commands
{
    public abstract class CarCommand : Command
    {
        protected CarRepository _carManager;
        public CarCommand(CarRepository carManager)
        {
            _carManager = carManager;
        }
    }
}

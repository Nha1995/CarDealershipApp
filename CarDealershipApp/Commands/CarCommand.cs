using System;
using System.Collections.Generic;
using System.Text;

namespace MyCarDealership
{
    public abstract class CarCommand : Command
    {
        protected CarRepository _carRepository;
        public CarCommand(CarRepository carRepository)
        {
            _carRepository = carRepository;
        }
    }
}

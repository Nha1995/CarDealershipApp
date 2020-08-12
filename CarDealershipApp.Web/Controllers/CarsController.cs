using CarDealershipDomain;
using CarDealershipRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipApp.Web.Controllers
{
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public ActionResult<List<Car>> Get(bool sold)
        {
            var res = _carRepository.List(sold);
            return Ok(res);
        }

        [HttpGet("{number}")]
        public ActionResult<Car> GetCarByNumber([FromRoute] string number)
        {
            var res = _carRepository.GetCarByNumber(number);

            if (res == null)
                return NotFound();

            return Ok(res);
        }

        [HttpPost]
        public ActionResult<Car> Create([FromBody] Car car)
        {
            var success = _carRepository.Add(car);
            if (!success)
            {
                return BadRequest($"Car with number: {car.Number} already exists");
            }

            return Ok(car);
        }
    }
}

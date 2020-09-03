using AutoMapper;
using CarDealershipApp.Web.Models;
using CarDealershipDomain;
using CarDealershipRepository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipApp.Web.Controllers
{
    [Route("Api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarsController(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<Car>> Get(bool sold)
        {
            try
            {
                var res = _carRepository.List(sold);
                return Ok(res);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }
            
        }

        [HttpGet("{number}")]
        public ActionResult GetCarByNumber([FromRoute] string number)
        {
            var res = _carRepository.GetCarByNumber(number);

            if (res == null)
                return NotFound();

            return Ok(res);
        }

        [HttpPost]
        public ActionResult<CarVm> Create([FromBody] CarBaseModel car)
        {
            var entity = _mapper.Map<Car>(car);
            var success = _carRepository.Add(entity);
            if (!success)
            {
                return BadRequest($"Car with number: {entity.Number} already exists");
            }

            var Vm = _mapper.Map<CarVm>(entity);
            return Ok(Vm);
        }
    }
}
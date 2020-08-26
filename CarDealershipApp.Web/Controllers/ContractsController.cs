using CarDealershipDomain;
using CarDealershipRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealershipApp.Web;
using CarDealershipApp.Web.Models;
using AutoMapper;

namespace CarDealershipApp.Web.Controllers
{
    [Route("[controller]")]
    public class ContractsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public ContractsController(IContractRepository contractRepository , ICarRepository carRepository, IClientRepository clientRepository, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _clientRepository = clientRepository;
            _carRepository = carRepository;
            _mapper = mapper;
        }
        

        [HttpGet]
        public ActionResult<List<Contract>> ListContracts()
        {
            var res = _contractRepository.ContractList();

            return Ok(res);
        }

        [HttpPost]
        public ActionResult<Contract> CreateContract([FromBody] CreateContractModel contractModel)
        {

            var client = _clientRepository.GetClientByPassportId(contractModel.PasspotId);
            if (client == null)
            {
                NotFound($"Client with Passport Id: {contractModel.PasspotId} does not exist.");
            }
            var car = _carRepository.GetCarByNumber(contractModel.CarNumber);
            if (car == null)
            {
                NotFound($"Car with number: {contractModel.CarNumber} does not exist.");
            }

            _carRepository.Sell(car, client);

            Contract contract = Contract.CreateContract(car,client);
            if (contractModel.isCredit == false)
            {
                contract.TotalCost = contract.Car.Price;
                contract.isCredit = contractModel.isCredit;
                contract.CarId = car.Id;
                contract.ClientId = client.Id;
            }
            else
            {                
                contract.TotalCost = (((car.Price - (double)contractModel.FirstPayment) / 10) * (double)(contractModel.CreditTerm / 12) + car.Price);
                contract.MonthlyPayment = (contract.TotalCost - contractModel.FirstPayment) / contractModel.CreditTerm;
                contract.FirstPayment = contractModel.FirstPayment;
                contract.CreditTerm = contractModel.CreditTerm;
                contract.isCredit = contractModel.isCredit;
                contract.CarId = car.Id;
                contract.ClientId = client.Id;
            }
            _contractRepository.AddContract(contract);
            return Ok(contract);

        }

    }
}
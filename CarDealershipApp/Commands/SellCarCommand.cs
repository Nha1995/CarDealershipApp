using CarDealershipApp;
using CarDealershipApp.Domain;
using CarDealershipApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipApp.Commands
{
    public class SellCarCommand : CarCommand
    {
        private ClientRepository _clientRepository;
        private ContractRepository _contractRepository;
        public SellCarCommand(ContractRepository contractRepository, CarRepository carRepository, ClientRepository clientRepository) : base(carRepository)
        {
            _clientRepository = clientRepository;
            _contractRepository = contractRepository;
        }

        public override string CommandText()
        {
            return "sell car";
        }

        public override CommandResult Execute()
        {
            Console.WriteLine("Car number for sale:");
            string carNumber = Console.ReadLine();
            Car car = _carRepository.GetCarByNumber(carNumber);
            if (car == null)
            {
                string message = $"No car with number {carNumber}";
                return new CommandResult(false, message);
            }
            if (car.Sold)
            {
                string message = $"Car with number {carNumber} is already sold";
                return new CommandResult(false, message);
            }
            Console.WriteLine("Sold buyer's Passport Id:");
            string PassportID = Console.ReadLine();
            Client client = _clientRepository.GetClientByPassportId(PassportID);
            if ( client == null)
            {
                string message = $"No client with Passport Id: {PassportID}";
                return new CommandResult(false, message);
            }
            _carRepository.Sell(car, client);
            Contract contract = new Contract(car, client);
            _contractRepository.AddContract(contract);
            return new CommandResult(true, "Car sold successfully");
        }
    }
}

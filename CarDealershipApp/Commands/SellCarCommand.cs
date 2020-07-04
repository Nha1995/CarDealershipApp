using CarDealershipApp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCarDealership
{
    public class SellCarCommand : CarCommand
    {
        private ClientRepository _clientRepository;
        private ContractRepository _contractRepository;
        public SellCarCommand(ContractRepository contractRepository ,CarRepository carRepository, ClientRepository clientRepository) : base(carRepository)
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
            Console.WriteLine("Sold buyer's Passport Id:");
            string PassportID = Console.ReadLine();            
            if (_carRepository.GetCarByNumber(carNumber) == null || _carRepository.GetCarByNumber(carNumber).Client != null)
            {
                string message = $"No car with number {carNumber}";
                return new CommandResult(false, message);
            }
            if (_clientRepository.GetClientByPassportId(PassportID) == null)
            {
                string message = $"No client with Passport Id: {PassportID}";
                return new CommandResult(false, message);
            }
            _carRepository.Sell(_carRepository.GetCarByNumber(carNumber), _clientRepository.GetClientByPassportId(PassportID));
            Contract contract = new Contract(_carRepository.GetCarByNumber(carNumber), _clientRepository.GetClientByPassportId(PassportID));
            _contractRepository.AddContract(contract);
            return new CommandResult(true, "Car sold successfully");
        }
    }
}

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
        private IClientRepository _clientRepository;
        private IContractRepository _contractRepository;
        public SellCarCommand(IContractRepository contractRepository, ICarRepository carRepository, IClientRepository clientRepository) : base(carRepository)
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
            if (client == null)
            {
                string message = $"No client with Passport Id: {PassportID}";
                return new CommandResult(false, message);
            }
            _carRepository.Sell(car, client);
            Contract contract = new Contract(car, client);

            Console.WriteLine("Payment type (cash or credit):");
            string paymentType = Console.ReadLine();
            while (paymentType != "credit" && paymentType != "cash")
            {
                Console.WriteLine("Enter the correct command");
                paymentType = Console.ReadLine();
            }
            if (paymentType == "cash")
            {
                contract.TotalCost = contract.Car.Price;
                contract.isCredit = false;
            }
            else
            {
                contract.isCredit = true;
                Console.WriteLine("Enter the amount of the first payment:");
                double firstPay = double.Parse(Console.ReadLine());
                Console.WriteLine("Credit term:");
                double Term = double.Parse(Console.ReadLine());
                contract.FirstPayment = firstPay;
                contract.CreditTerm = Term;
                contract.TotalCost = ((contract.Car.Price - contract.FirstPayment) / 10) * (contract.CreditTerm / 12) + contract.Car.Price;
                contract.MonthlyPayment = (contract.TotalCost - contract.FirstPayment) / contract.CreditTerm;
            }

            _contractRepository.AddContract(contract);
            return new CommandResult(true, "Car sold successfully");
        }
    }
}

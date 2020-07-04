using CarDealershipApp;
using CarDealershipApp.Commands;
using CarDealershipApp.Domain;
using CarDealershipApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipApp.DisplayCommands
{
    internal class DisplayContracts : ContractCommand
    {
        public DisplayContracts(ContractRepository contractRepository) : base(contractRepository) { }
        public override string CommandText()
        {
            return "display contracts";
        }

        public override CommandResult Execute()
        {
            Console.WriteLine();
            foreach(Contract contract in _contractRepository.ContractList())
            {
                if (contract.isCredit)
                {
                    Console.WriteLine($"Client: {contract.Client.Surname} {contract.Client.Name} Passport Id: {contract.Client.PassportId}");
                    Console.WriteLine($"ID: {contract.Car.Id} Number: {contract.Car.Number} Model: {contract.Car.Model} Year: {contract.Car.YearMaking} Color: {contract.Car.Color}");
                    Console.WriteLine($"Credit number: {contract.CreditNumber} \nTotal cost: {contract.TotalCost} \nFirst Payment: {contract.FirstPayment} \nCredit term: {contract.CreditTerm} \n Monthly Payment: {contract.MonthlyPayment}");
                    Console.WriteLine("______________________________________________________________");
                }
                else
                {
                    Console.WriteLine($"Client: {contract.Client.Surname} {contract.Client.Name} Passport Id: {contract.Client.PassportId}");
                    Console.WriteLine($"ID: {contract.Car.Id} Number: {contract.Car.Number} Model: {contract.Car.Model} Year: {contract.Car.YearMaking} Color: {contract.Car.Color} Price: {contract.TotalCost}");
                }
            }
            if (_contractRepository.Count() > 1)
            {
                return new CommandResult(true, $"Listed {_contractRepository.Count()} contracts");
            }
            if (_contractRepository.Count() == 1)
            {
                return new CommandResult(true, $"{_contractRepository.Count()} contract is listed");
            }
                return new CommandResult(false, "You have no contracts");
        }
    }
}

using CarDealershipApp;
using CarDealershipApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipApp.Repository
{
    public class ContractRepository
    {
        private static long CurrentId=0;
        private readonly LinkedList<Contract> _contracts;
        public ContractRepository()
        {
            _contracts = new LinkedList<Contract>();
        }
        public int Count()
        {
            return _contracts.Count;
        }
        public LinkedList<Contract> ContractList()
        {
            return _contracts;
        }
        public void AddContract(Contract contract)
        {
            _contracts.AddLast(contract);
            Console.WriteLine("Payment type (cash or credit):");
            string message = Console.ReadLine();
            while (message != "credit" && message != "cash")
            {
                Console.WriteLine("Enter the correct command");
                message = Console.ReadLine();
            }
            if(message == "cash")
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
                contract.TotalCost = ((contract.Car.Price-contract.FirstPayment) / 10) * (contract.CreditTerm / 12) + contract.Car.Price;
                contract.MonthlyPayment = (contract.TotalCost - contract.FirstPayment) / contract.CreditTerm;
                contract.CreditNumber = ++CurrentId;
            }
        }
    }
}
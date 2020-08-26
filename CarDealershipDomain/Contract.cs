using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipDomain
{
    public class Contract
    {
        public Client Client { get; set; }
        public Car Car { get; set; }
        public long Id { get; set; }
        public long ClientId { get; set; }
        public long CarId { get; set; }
        public double TotalCost { get; set; }
        public double? FirstPayment { get; set; }
        public double? CreditTerm { get; set; }
        public double? MonthlyPayment { get; set; }
        public bool isCredit { get; set; }
        public Contract()
        {

        }
        public static Contract CreateContract(Car car, Client client)
        {
            Contract contract = new Contract
            {
                Client = client,
                Car = car
            };
            return contract;
        }
        public static Contract CreateContract(long ClientId, long CarId, double TotalCost, double FirstPayment, double CreditTerm, double MonthlyPayment, bool isCredit)
        {
            Contract contract = new Contract
            {
                ClientId = ClientId,
                CarId = CarId,
                TotalCost = TotalCost,
                FirstPayment = FirstPayment,
                CreditTerm = CreditTerm,
                MonthlyPayment = MonthlyPayment,
                isCredit = isCredit
            };
            return contract;
        }
    }
}
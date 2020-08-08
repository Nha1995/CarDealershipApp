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
        public double FirstPayment { get; set; }
        public double CreditTerm { get; set; }
        public double MonthlyPayment { get; set; }
        public bool isCredit { get; set; }
        public Contract(Car car, Client client)
        {
            Client = client;
            Car = car;
        }
        public Contract(long ClientId, long CarId, double TotalCost, double FirstPayment, double CreditTerm, double MonthlyPayment, bool isCredit)
        {
            this.ClientId = ClientId;
            this.CarId = CarId;
            this.TotalCost = TotalCost;
            this.FirstPayment = FirstPayment;
            this.CreditTerm = CreditTerm;
            this.MonthlyPayment = MonthlyPayment;
            this.isCredit = isCredit;
        }
    }
}
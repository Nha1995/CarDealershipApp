using CarDealershipApp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipApp.Domain
{
    public class Contract
    {
        public Client Client;
        public Car Car;
        public long Id;
        public long ClientId;
        public long CarId;
        public double TotalCost;
        public double FirstPayment;
        public double CreditTerm;
        public double MonthlyPayment;
        public bool isCredit;
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
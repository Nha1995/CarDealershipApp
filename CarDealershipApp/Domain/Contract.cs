using MyCarDealership;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipApp
{
    public class Contract
    {
        public Client Client;
        public Car Car;
        public long Id;
        public long  CreditNumber;
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
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CarDealershipApp.Domain
{
    public class Car
    {
        public string Number;
        public string Model;
        public string YearMaking;
        public string Color;
        public int Price;
        public long Id;
        public bool Sold;

        public Client Client;
        public Car(string number, string model, string yearmaking, string color, int price)
        {
            Number = number;
            Model = model;
            YearMaking = yearmaking;
            Color = color;
            Price = price;
        }
    }
}

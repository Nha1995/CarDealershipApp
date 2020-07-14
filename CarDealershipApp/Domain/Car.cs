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
        public int Year;
        public string Color;
        public int Price;
        public long Id;
        public bool Sold;
        public Client Client;

        public Car(string number, string model, int yearmaking, string color, int price)
        {
            Number = number;
            Model = model;
            Year = yearmaking;
            Color = color;
            Price = price;
        }

        public Car(long id, bool sold, string number, string model, int yearmaking, string color, int price)
        {
            Number = number;
            Model = model;
            Year = yearmaking;
            Color = color;
            Price = price;
            Id = id;
            Sold = sold;
        }
    }
}

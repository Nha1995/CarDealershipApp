using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CarDealershipDomain
{
    public class Car
    {
        public string Number { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public long Id { get; set; }
        public bool Sold { get; set; }
        public Client Client { get; set; }
        public long ClientId { get; set; }

        public Car()
        {

        }

        public static Car CreateCar(string number, string model, int yearmaking, string color, int price)
        {
            Car car = new Car
            {
                Number = number,
                Model = model,
                Year = yearmaking,
                Color = color,
                Price = price
            };
            return car;
        }

        public static Car CreateCar(long id, bool sold, string number, string model, int yearmaking, string color, int price)
        {
            Car car = new Car
            {
                Number = number,
                Model = model,
                Year = yearmaking,
                Color = color,
                Price = price,
                Id = id,
                Sold = sold
            };

            return car;
        }
    }
}

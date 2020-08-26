using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipApp.Web.Models
{
    public class CarBaseModel
    {
        public string Number { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
    }
}

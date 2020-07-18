using CarDealershipApp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealershipApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            General general = new General("Server=localhost\\SQLEXPRESS;Database=CarDealership; Integrated Security=true");
            general.Start();
        }
    }
}
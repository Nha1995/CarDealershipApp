using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipDomain
{
    public class Client
    {
        public string PassportId;
        public string Surname;
        public string Name;
        public long Id;
        public List<Car> Cars;
        public Client(string passportId, string surname, string name)
        {
            PassportId = passportId;
            Surname = surname;
            Name = name;
            Cars = new List<Car>();
        }
        public Client(long id, string passportId, string surname, string name)
        {
            PassportId = passportId;
            Surname = surname;
            Name = name;
            Cars = new List<Car>();
            Id = id;
        }
    }
}
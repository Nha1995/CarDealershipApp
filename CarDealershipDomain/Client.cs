using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipDomain
{
    public class Client
    {
        public string PassportId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public long Id { get; set; }
        public List<Car> Cars { get; set; }

        public Client()
        {

        }

        public static Client CreateClient(string passportId, string surname, string name)
        {
            Client client = new Client
            {
                PassportId = passportId,
                Surname = surname,
                Name = name,
                Cars = new List<Car>(),
            };

            return client;
        }
        public static Client CreateClient(long id, string passportId, string surname, string name)
        {
            Client client = new Client
            {
                PassportId = passportId,
                Surname = surname,
                Name = name,
                Cars = new List<Car>(),
                Id = id
            };

            return client;
        }
    }
}
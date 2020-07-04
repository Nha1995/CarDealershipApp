using CarDealershipApp.Domain;
using CarDealershipApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipApp.Commands
{
    class ListClientsCommand : ClientCommand
    {
        public ListClientsCommand(ClientRepository _clRepository) : base(_clRepository) { }

        public override string CommandText()
        {
            return "list client";
        }

        public override CommandResult Execute()
        {
            string ID;
            Console.WriteLine();
            foreach (Client client in _ClientRepository.ClientList())
            {
                Console.WriteLine($"ID: {client.Id} Client passportID: {client.PassportId} Name: {client.Name} Surname: {client.Surname}");
                if (client.Cars.Count > 0)
                {
                    Console.WriteLine("Client cars: ");
                    for (int i =0;i<client.Cars.Count;i++)
                    {
                        Console.WriteLine($"ID: {client.Cars[i].Id} Number: {client.Cars[i].Number} Model: {client.Cars[i].Model} Year: {client.Cars[i].YearMaking} Color: {client.Cars[i].Color} Price: {client.Cars[i].Price}");
                    }
                }
                Console.WriteLine("______________________________________________________________");
                ID = client.PassportId;
            }
            if (_ClientRepository.Count() > 1)
            {
                return new CommandResult(true, $"Listed {_ClientRepository.Count()} clients");
            }
            else
            {
                return new CommandResult(true, $"{_ClientRepository.Count()} client is listed");
            }
        }
    }
}

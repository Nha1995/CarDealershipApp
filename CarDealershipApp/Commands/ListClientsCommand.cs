using CarDealershipDomain;
using CarDealershipRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipCommands
{
    public class ListClientsCommand : ClientCommand
    {
        public IClientRepository clientRepository;

        public ListClientsCommand(IClientRepository _clRepository) : base(_clRepository) { }


        public override string CommandText()
        {
            return "list clients";
        }

        public override CommandResult Execute()
        {
            string ID;
            Console.WriteLine();
            bool WithCars = false;
            foreach (Client client in _ClientRepository.ClientList(WithCars))
            {
                Console.WriteLine($"ID: {client.Id} Client passportID: {client.PassportId} Name: {client.Name} Surname: {client.Surname}");
                if (client.Cars.Count > 0)
                {
                    Console.WriteLine("Client cars: ");
                    for (int i =0;i<client.Cars.Count;i++)
                    {
                        Console.WriteLine($"ID: {client.Cars[i].Id} Number: {client.Cars[i].Number} Model: {client.Cars[i].Model} Year: {client.Cars[i].Year} Color: {client.Cars[i].Color} Price: {client.Cars[i].Price}");
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

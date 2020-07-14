using CarDealershipApp.Commands;
using CarDealershipApp.Domain;
using CarDealershipApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipApp.DisplayCommands
{
    public class DisplayClientsWithCar : ClientCommand
    {
        public DisplayClientsWithCar(IClientRepository _clRepository) : base(_clRepository) { }
        public override string CommandText()
        {
            return "display clients with car";
        }

        public override CommandResult Execute()
        {
            bool sold = true;
            Console.WriteLine();
            foreach (Client client in _ClientRepository.ClientList())
            {
                if (client.Cars.Count != 0)
                {
                    Console.WriteLine($"{client.Surname} {client.Name} Passport Id: {client.PassportId} \n Client cars:");
                    foreach (Car car in client.Cars)
                    {
                        Console.WriteLine($"ID: {car.Id} Number: {car.Number} Model: {car.Model} Year: {car.Year} Color: {car.Color} Price: {car.Price}");
                    }
                }
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

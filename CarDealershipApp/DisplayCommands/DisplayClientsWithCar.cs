using CarDealershipCommands;
using CarDealershipDomain;
using CarDealershipRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            bool WithCars = true;
            Console.WriteLine();
            var clients = _ClientRepository.ClientList(WithCars);
            foreach (var client in clients)
            {
                    Console.WriteLine($"{client.Surname} {client.Name} Passport Id: {client.PassportId} \n Client cars:");
                    foreach (Car car in client.Cars)
                    {
                        Console.WriteLine($"ID: {car.Id} Number: {car.Number} Model: {car.Model} Year: {car.Year} Color: {car.Color} Price: {car.Price}");
                    }
            }

            if (clients.Count > 1)
            {
                return new CommandResult(true, $"Listed {clients.Count} clients");
            }
            else
            {
                return new CommandResult(true, $"{clients.Count} client is listed");
            }
        }
    }
}

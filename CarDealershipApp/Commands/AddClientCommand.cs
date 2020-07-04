using CarDealershipApp.Domain;
using CarDealershipApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipApp.Commands
{
    public class AddClientCommand : ClientCommand
    {
        public AddClientCommand(ClientRepository _clRepository) : base(_clRepository) { }
        public override string CommandText()
        {
            return "add client";
        }

        public override CommandResult Execute()
        {
            Console.WriteLine("Write client passportID, surname and name(on one line):");
            string[] clientdata = Console.ReadLine().Split(' ');
            Client client = new Client(clientdata[0], clientdata[1], clientdata[2]);
            bool success = _ClientRepository.AddClient(client);
            string message = "Client added successfully";
            if (!success)
            {
                message = "A person with this ID is already our client.";
            }
            return new CommandResult(success, message);
        }
    }
}

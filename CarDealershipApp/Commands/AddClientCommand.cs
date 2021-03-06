﻿using CarDealershipDomain;
using CarDealershipRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipCommands
{
    public class AddClientCommand : ClientCommand
    {
        public AddClientCommand(IClientRepository _clRepository) : base(_clRepository) { }
        public override string CommandText()
        {
            return "add client";
        }

        public override CommandResult Execute()
        {
            Console.WriteLine("Write client passportID, surname and name(on one line):");
            string[] clientdata = Console.ReadLine().Split(' ');
            Client client = Client.CreateClient(clientdata[0], clientdata[1], clientdata[2]);
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

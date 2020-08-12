using CarDealershipApp;
using CarDealershipCommands;
using CarDealershipApp.DisplayCommands;
using CarDealershipRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using CarDealershipRepository.AdoNet;
using CarDealershipApp.Options;
using CarDealershipRepository.InMemory;
using CarDealershipRepository.Ef;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Xml;

namespace CarDealershipApp
{
    public class General
    {
        private readonly List<Command> _commands;
        private readonly ICarRepository _carRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IContractRepository _contractRepository;

        public General(ICarRepository carRepository,
            IClientRepository clientRepository,
            IContractRepository contractRepository)
        {
            _carRepository = carRepository;
            _clientRepository = clientRepository;
            _contractRepository = contractRepository;

            _commands = new List<Command>();
            _commands.Add(new ListClientsCommand(_clientRepository));
            _commands.Add(new AddCarCommand(_carRepository));
            _commands.Add(new SellCarCommand(_contractRepository, _carRepository, _clientRepository));
            _commands.Add(new ListCarsCommand(_carRepository));
            _commands.Add(new AddClientCommand(_clientRepository));
            _commands.Add(new DisplaySoldCars(_carRepository));
            _commands.Add(new DisplayClientsWithCar(_clientRepository));
            _commands.Add(new DisplayContracts(_contractRepository));
        }
        public void Start()
        {
            ConsoleHelper.WriteLineColored("Please choose a command: ", ConsoleColor.White);
            string commandText = Console.ReadLine();


            while (commandText != "end")
            {
                var curCommand = _commands.FirstOrDefault(c => c.CommandText() == commandText);

                if (curCommand == null)
                {
                    ConsoleHelper.WriteLineError("Wrong command, please enter correct command: ");
                }
                else
                {
                    ExecuteCommand(curCommand);
                    Console.WriteLine("Please choose a command: ");
                }

                commandText = Console.ReadLine();
            }
        }

        private void ExecuteCommand(Command command)
        {
            CommandResult commandResult = command.Execute();

            if (!commandResult.Success)
            {
                ConsoleHelper.WriteLineError(commandResult.Message);
            }
            else
            {
                ConsoleHelper.WriteLineSuccess(commandResult.Message);
            }            
        }
    }
}
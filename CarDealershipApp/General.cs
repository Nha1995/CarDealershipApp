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

namespace CarDealershipApp
{
    public class General
    {
        private readonly List<Command> _commands;
        private readonly ICarRepository _carRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IContractRepository _contractRepository;

        public General(AppOptions appOptions)
        {
            string connectionString = appOptions.ConnectionString;
            switch (appOptions.Mode)
            {
                case AppMode.InMemory:
                    _contractRepository = new ContractMemoryRepository();
                    _clientRepository = new ClientMemoryRepository();
                    _carRepository = new CarMemoryRepository();
                    break;
                case AppMode.AdoNet:
                    _contractRepository = new ContractDbRepository(connectionString);
                    _clientRepository = new ClientDbRepository(connectionString);
                    _carRepository = new CarDbRepository(connectionString);
                    break;
                case AppMode.Ef:
                    var dbContext = CreateDbContext(appOptions.ConnectionString);
                    _carRepository = new CarEfRepository(dbContext);
                    break;
            }
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
            Console.WriteLine("Please choose a command: ");
            string commandText = Console.ReadLine();


            while (commandText != "end")
            {
                Command curCommand = null;
                for (int i = 0; i < _commands.Count; ++i)
                {
                    if (_commands[i].CommandText() == commandText)
                    {
                        curCommand = _commands[i];
                        break;
                    }
                }

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

        private CarDealershipDbContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarDealershipDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new CarDealershipDbContext(optionsBuilder.Options);
        }

        private void ExecuteCommand(Command command)
        {
            CommandResult commandResult = command.Execute();

            ConsoleColor color = ConsoleColor.Green;
            if (!commandResult.Success)
            {
                color = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Red;
            }

            ConsoleHelper.WriteLineColored(commandResult.Message, color);
        }
    }
}

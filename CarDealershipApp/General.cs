using CarDealershipApp;
using CarDealershipApp.Commands;
using CarDealershipApp.DisplayCommands;
using CarDealershipApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipApp
{
    public class General
    {
        private readonly List<Command> _commands;
        private readonly ICarRepository _carRepository;
        private readonly ClientRepository _clientRepository;
        private readonly ContractRepository _contractRepository;

        public General()
        {
            _contractRepository = new ContractRepository();
            _clientRepository = new ClientRepository();
            _carRepository = new CarDbRepository("Server=.;Database=CarDealership; Integrated Security=true");
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

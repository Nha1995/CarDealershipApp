using CarDealershipApp;
using CarDealershipApp.Options;
using CarDealershipRepository.AdoNet;
using CarDealershipRepository.Ef;
using CarDealershipRepository.InMemory;
using CarDealershipRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealershipApp
{
    public class Program
    {
        private static CarDealershipDbContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarDealershipDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new CarDealershipDbContext(optionsBuilder.Options);
        }

        static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            IConfigurationRoot configuration = builder.Build();

            AppOptions appOptions = new AppOptions();
            configuration.GetSection("AppOptions").Bind(appOptions);

            string connectionString = appOptions.ConnectionString;

            var services = new ServiceCollection();

            ICarRepository carRepository = null;
            IClientRepository clientRepository = null;
            IContractRepository contractRepository = null;
            switch (appOptions.Mode)
            {
                case AppMode.InMemory:
                    contractRepository = new ContractMemoryRepository();
                    clientRepository = new ClientMemoryRepository();
                    carRepository = new CarMemoryRepository();
                    break;
                case AppMode.AdoNet:
                    contractRepository = new ContractDbRepository(connectionString);
                    clientRepository = new ClientDbRepository(connectionString);
                    carRepository = new CarDbRepository(connectionString);
                    break;
                case AppMode.Ef:
                    services.AddDbContext<CarDealershipDbContext>(cfg => cfg.UseSqlServer(connectionString));
                    //All above has to be replaced with service registration in services
                    var dbContext = CreateDbContext(appOptions.ConnectionString);
                    carRepository = new CarEfRepository(dbContext);
                    clientRepository = new ClientEfRepository(dbContext);
                    contractRepository = new ContractEfRepository(dbContext);
                    break;
            }

            General general = new General(carRepository, clientRepository, contractRepository);
            general.Start();
        }
    }
}
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
            appOptions.Mode = configuration.GetValue<AppMode>("AppOptions:Mode");
            appOptions.ConnectionString = configuration.GetValue<string>("AppOptions:ConnectionString");

            var services = new ServiceCollection();
            
            switch (appOptions.Mode)
            {
                case AppMode.InMemory:
                    services.AddSingleton<ICarRepository, CarMemoryRepository>();
                    services.AddSingleton<IClientRepository, ClientMemoryRepository>();
                    services.AddSingleton<IContractRepository, ContractMemoryRepository>();
                    break;
                case AppMode.AdoNet:
                    services.AddSingleton(new AdoNetOptions { ConnectionString = appOptions.ConnectionString });
                    services.AddSingleton<ICarRepository, CarDbRepository>();
                    services.AddSingleton<IClientRepository, ClientDbRepository>();
                    services.AddSingleton<IContractRepository, ContractDbRepository>();
                    break;
                case AppMode.Ef:
                    services.AddDbContext<CarDealershipDbContext>(cfg => cfg.UseSqlServer(appOptions.ConnectionString));
                    //All above has to be replaced with service registration in services
                    services.AddSingleton<ICarRepository, CarEfRepository>();
                    services.AddSingleton<IClientRepository, ClientEfRepository>();
                    services.AddSingleton<IContractRepository, ContractEfRepository>();
                    break;
            }

            services.AddSingleton<General>();

            var serviceProvider = services.BuildServiceProvider();

            General general = serviceProvider.GetRequiredService<General>();
            general.Start();
        }
    }
}
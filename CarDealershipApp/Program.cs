using CarDealershipApp;
using CarDealershipApp.Options;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealershipApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            IConfigurationRoot configuration = builder.Build();

            AppOptions appOptions = new AppOptions();
            configuration.GetSection("AppOptions").Bind(appOptions);

            General general = new General(appOptions);
            general.Start();
        }
    }
}
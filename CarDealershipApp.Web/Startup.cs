using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarDealershipApp.Options;
using CarDealershipRepository.AdoNet;
using CarDealershipRepository.Ef;
using CarDealershipRepository.InMemory;
using CarDealershipRepository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CarDealershipApp.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        

        public void ConfigureServices(IServiceCollection services)
        {
            AppOptions appOptions = new AppOptions();
            appOptions.Mode = Configuration.GetValue<AppMode>("AppOptions:Mode");
            appOptions.ConnectionString = Configuration.GetValue<string>("AppOptions:ConnectionString");
            services.AddAutoMapper();
            services.AddControllers()             
                .AddNewtonsoftJson(options =>options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

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
                    services.AddScoped<ICarRepository, CarEfRepository>();
                    services.AddScoped<IClientRepository, ClientEfRepository>();
                    services.AddScoped<IContractRepository, ContractEfRepository>();
                    services.AddDbContext<CarDealershipDbContext>(cfg => cfg.UseSqlServer(appOptions.ConnectionString));
                    break;
            }
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

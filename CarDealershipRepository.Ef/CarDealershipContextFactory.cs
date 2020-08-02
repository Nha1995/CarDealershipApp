using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipRepository.Ef
{
    public class CarDealershipContextFactory : IDesignTimeDbContextFactory<CarDealershipDbContext>
    {
        public CarDealershipDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarDealershipDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=CarDealershipEf; Integrated Security=true");

            return new CarDealershipDbContext(optionsBuilder.Options);
        }
    }
}

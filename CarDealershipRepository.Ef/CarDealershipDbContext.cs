using CarDealershipDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipRepository.Ef
{
    public class CarDealershipDbContext : DbContext
    {
        public CarDealershipDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            

            builder.Entity<Car>()
                .HasKey(c => c.Id);

            builder.Entity<Car>()
                .HasIndex(c => c.Number)
                .IsUnique();

            builder.Entity<Client>()
                .HasKey(c => c.Id);

            builder.Entity<Client>()
                .HasIndex(c => c.PassportId)
                .IsUnique();

            builder.Entity<Car>()
                .HasOne(car => car.Client)
                .WithMany(client => client.Cars)
                .HasForeignKey(car => car.ClientId)
                .IsRequired(false);

            builder.Entity<Contract>()
                .HasKey(c => c.Id);

            builder.Entity<Contract>()
                .HasOne(c => c.Client)
                .WithMany()
                .HasForeignKey(c => c.ClientId);

            builder.Entity<Contract>()
                .HasOne(c => c.Car)
                .WithOne()
                .HasForeignKey<Contract>(c => c.CarId);

        }
    }
}

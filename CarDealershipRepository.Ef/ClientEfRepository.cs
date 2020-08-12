using CarDealershipDomain;
using CarDealershipRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipRepository.Ef
{
    public class ClientEfRepository : EfRepository, IClientRepository
    {
        public ClientEfRepository(CarDealershipDbContext dbContext) : base(dbContext) { }

        public bool AddClient(Client client)
        {
            var existingClient = _dbContext.Clients.FirstOrDefault(c => c.PassportId == client.PassportId);
            if (existingClient != null)
            {
                return false;
            }

            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Client> ClientList(bool WithCars)
        {
            var query = _dbContext.Clients.Include(c => c.Cars).AsQueryable();
            if (WithCars == true)
            {
                query = query.Where(c => c.Cars.Any());
            }
            return query.ToList();
        }

        public int Count()
        {
            return _dbContext.Clients.Count();
        }

        public Client GetClientByPassportId(string passportId)
        {
            var client = _dbContext.Clients.FirstOrDefault(c => c.PassportId == passportId);
            return client;
        }
    }
}
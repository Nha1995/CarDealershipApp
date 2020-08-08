﻿using CarDealershipDomain;
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

        public List<Client> ClientList()
        {
            List<Client> clients = _dbContext.Clients
                .Include(c => c.Cars)
                .ToList();
            return clients;
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

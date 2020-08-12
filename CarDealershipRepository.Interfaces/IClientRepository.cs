using System;
using System.Collections.Generic;
using System.Text;
using CarDealershipDomain;

namespace CarDealershipRepository.Interfaces
{
    public interface IClientRepository
    {
        public int Count();

        List<Client> ClientList(bool WithCars);

        public bool AddClient(Client client);

        public Client GetClientByPassportId(string passportId);
    }
}
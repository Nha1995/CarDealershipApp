using System;
using System.Collections.Generic;
using System.Text;
using CarDealershipDomain;

namespace CarDealershipRepository.Interfaces
{
    public interface IClientRepository
    {
        int Count();

        List<Client> ClientList(bool WithCars);

        bool AddClient(Client client);

        Client GetClientByPassportId(string passportId);
    }
}
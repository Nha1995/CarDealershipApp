using System;
using System.Collections.Generic;
using System.Text;
using CarDealershipDomain;

namespace CarDealershipRepository.Interfaces
{
    public interface IClientRepository
    {
        public int Count();

        LinkedList<Client> ClientList();

        public bool AddClient(Client client);

        public Client GetClientByPassportId(string passportId);
    }
}

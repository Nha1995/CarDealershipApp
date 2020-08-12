using CarDealershipDomain;
using CarDealershipRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipRepository.InMemory
{
    public class ClientMemoryRepository : IClientRepository
    {
        private static long CurrentID = 0;
        private readonly List<Client> _clients;
        public ClientMemoryRepository()
        {
            _clients = new List<Client>();
        }
        public int Count()
        {
            return _clients.Count;
        }
        public List<Client> ClientList(bool WithCars)
        {
                return _clients;
        }
        public bool AddClient(Client client)
        {
            for (int i = 0; i < _clients.Count; i++)
            {
                foreach (Client cl in _clients)
                {
                    if(cl.PassportId==client.PassportId)
                    return false;
                }
            }
            _clients.Add(client);
            client.Id = ++CurrentID;
            return true;
        }
        public Client GetClientByPassportId(string passportId)
        {
            foreach (Client a in _clients)
            {
                if (a.PassportId == passportId)
                {
                    return a;
                }
            }
            return null;
        }
    }
}
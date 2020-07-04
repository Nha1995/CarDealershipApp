using System;
using System.Collections.Generic;
using System.Text;

namespace MyCarDealership
{
    public class ClientRepository
    {
        private static long CurrentID = 0;
        private readonly LinkedList<Client> _clients;
        public ClientRepository()
        {
            _clients = new LinkedList<Client>();
        }
        public int Count()
        {
            return _clients.Count;
        }
        public LinkedList<Client> ClientList()
        {
            return _clients;
        }
        public bool AddClient(Client client)
        {
            LinkedListNode<Client> node;
            for (node = _clients.First; node != null; node = node.Next)
            {
                if (node.Value.PassportId == client.PassportId)
                {
                    return false;
                }
            }
            _clients.AddLast(client);
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

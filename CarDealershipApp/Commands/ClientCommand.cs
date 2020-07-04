using System;
using System.Collections.Generic;
using System.Text;

namespace MyCarDealership
{
    public abstract class ClientCommand : Command
    {
        protected ClientRepository _ClientRepository;
        public ClientCommand(ClientRepository _clRepository)
        {
            _ClientRepository = _clRepository;
        }
    }
}

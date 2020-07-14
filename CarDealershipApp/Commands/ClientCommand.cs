using CarDealershipApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipApp.Commands
{
    public abstract class ClientCommand : Command
    {
        protected IClientRepository _ClientRepository;
        public ClientCommand(IClientRepository _clRepository)
        {
            _ClientRepository = _clRepository;
        }
    }
}

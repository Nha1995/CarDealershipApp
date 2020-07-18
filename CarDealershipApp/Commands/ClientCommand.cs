using CarDealershipRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipCommands
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

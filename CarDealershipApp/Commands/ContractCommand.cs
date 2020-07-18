using CarDealershipRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipCommands
{
    public abstract class ContractCommand : Command
    {
        protected IContractRepository _contractRepository;
        public ContractCommand(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }
    }
}
using CarDealershipApp;
using CarDealershipApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipApp.Commands
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
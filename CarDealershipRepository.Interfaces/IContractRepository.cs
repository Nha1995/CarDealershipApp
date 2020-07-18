using System;
using System.Collections.Generic;
using System.Text;
using CarDealershipDomain;

namespace CarDealershipRepository.Interfaces
{
    public interface IContractRepository
    {
        public int Count();

        LinkedList<Contract> ContractList();

        public void AddContract(Contract contract);

    }
}
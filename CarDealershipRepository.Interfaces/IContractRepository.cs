using System;
using System.Collections.Generic;
using System.Text;
using CarDealershipDomain;

namespace CarDealershipRepository.Interfaces
{
    public interface IContractRepository
    {
        public int Count();

        List<Contract> ContractList();

        public void AddContract(Contract contract);

    }
}
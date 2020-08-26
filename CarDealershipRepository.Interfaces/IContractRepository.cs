using System;
using System.Collections.Generic;
using System.Text;
using CarDealershipDomain;

namespace CarDealershipRepository.Interfaces
{
    public interface IContractRepository
    {
        int Count();

        List<Contract> ContractList();

        void AddContract(Contract contract);

    }
}
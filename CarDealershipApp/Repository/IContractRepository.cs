using System;
using System.Collections.Generic;
using System.Text;
using CarDealershipApp.Domain;

namespace CarDealershipApp.Repository
{
    public interface IContractRepository
    {
        public int Count();

        LinkedList<Contract> ContractList();

        public void AddContract(Contract contract);

    }
}

using CarDealershipApp;
using CarDealershipDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipApp.Repository
{
    public class ContractMemoryRepository : IContractRepository
    {
        private static long CurrentId=0;
        private readonly LinkedList<Contract> _contracts;
        public ContractMemoryRepository()
        {
            _contracts = new LinkedList<Contract>();
        }
        public int Count()
        {
            return _contracts.Count;
        }
        public LinkedList<Contract> ContractList()
        {
            return _contracts;
        }
        public void AddContract(Contract contract)
        {
            contract.Id = ++CurrentId;
            _contracts.AddLast(contract);
        }
    }
}
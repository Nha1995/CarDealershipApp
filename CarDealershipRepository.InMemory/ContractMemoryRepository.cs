using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using CarDealershipDomain;
using CarDealershipRepository.Interfaces;

namespace CarDealershipRepository.InMemory
{
    public class ContractMemoryRepository : IContractRepository
    {
        private static long CurrentId=0;
        private readonly LinkedList<CarDealershipDomain.Contract> _contracts;
        public ContractMemoryRepository()
        {
            _contracts = new LinkedList<CarDealershipDomain.Contract>();
        }
        public int Count()
        {
            return _contracts.Count;
        }
        public LinkedList<CarDealershipDomain.Contract> ContractList()
        {
            return _contracts;
        }
        public void AddContract(CarDealershipDomain.Contract contract)
        {
            contract.Id = ++CurrentId;
            _contracts.AddLast(contract);
        }
    }
}
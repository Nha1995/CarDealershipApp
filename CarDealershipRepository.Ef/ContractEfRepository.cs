using CarDealershipDomain;
using CarDealershipRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipRepository.Ef
{
    public class ContractEfRepository : EfRepository, IContractRepository
    {
        public ContractEfRepository(CarDealershipDbContext dbContext) : base(dbContext) { }
        public void AddContract(Contract contract)
        {
            var boolSold = _dbContext.Contracts.FirstOrDefault(c => c.Car.Sold==true);

            
            _dbContext.Add(contract);
            _dbContext.SaveChanges();
        }

        public List<Contract> ContractList()
        {
            List<Contract> contracts = _dbContext.Contracts
                .ToList();
            return contracts;
        }

        public int Count()
        {
            return _dbContext.Contracts.Count();
        }
    }
}
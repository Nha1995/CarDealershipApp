using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealershipRepository.Ef
{
    public abstract class EfRepository
    {
        protected readonly CarDealershipDbContext _dbContext;
        public EfRepository(CarDealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WareHouse.Models.Context;
using WareHouse.Models.DbModels;

namespace WareHouse.Models.Repositories
{
    public interface IIncomeRepository :IGenericRepository<Income>
    {
        IEnumerable<Income> GetOrderWithRelations { get; }
    }
    public class IncomeRepository :GenericRepository<Income>, IIncomeRepository
    {
        ApplicationDbContext _dbcontext;
        public IncomeRepository(ApplicationDbContext applicationDb):base(applicationDb)
        {
            _dbcontext = applicationDb;
        }

        public IEnumerable<Income> GetOrderWithRelations => _dbcontext.Incomes
            .Include(x=>x.IncomeItemCollection)
            .Include(x=>x.ProviderTable)
            .AsNoTracking();
    }
}

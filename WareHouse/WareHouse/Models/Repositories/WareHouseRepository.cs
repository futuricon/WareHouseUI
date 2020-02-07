using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Models.Context;
using WareHouse.Models.DbModels;

namespace WareHouse.Models.Repositories
{
	public interface IWareHouseRepository:IGenericRepository<WareHouseTable>
	{	
	}

	public class WareHouseRepository : GenericRepository<WareHouseTable>,IWareHouseRepository
	{
		//ApplicationDbContext _dbcontext;
		public WareHouseRepository(ApplicationDbContext applicationDb):base(applicationDb)
		{}	
	}
}

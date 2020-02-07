using System;
using System.Collections.Generic;
using System.Text;
using WareHouse.Models.Context;
using WareHouse.Models.DbModels;

namespace WareHouse.Models.Repositories
{
	public interface IProviderRepository:IGenericRepository<ProviderTable>
	{

	}
	public class ProviderRepository:GenericRepository<ProviderTable>, IProviderRepository
	{
		public ProviderRepository(ApplicationDbContext applicationDb) : base(applicationDb)
		{
		}
	}
}

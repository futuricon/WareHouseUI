using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Models.Context;
using WareHouse.Models.DbModels;

namespace WareHouse.Models.Repositories
{
	public interface IClientRepository:IGenericRepository<Client>
	{}
	public class ClientRepositroy :GenericRepository<Client>, IClientRepository
	{
		//ApplicationDbContext _dbcontext;
		public ClientRepositroy(ApplicationDbContext applicationDbContext):base(applicationDbContext)
		{}		
	}
}

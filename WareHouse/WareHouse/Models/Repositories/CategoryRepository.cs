using System;
using System.Collections.Generic;
using System.Text;
using WareHouse.Models.Context;
using WareHouse.Models.DbModels;

namespace WareHouse.Models.Repositories
{
	public interface ICategoryRepository:IGenericRepository<Category>
	{

	}
	public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
	{
		public CategoryRepository(ApplicationDbContext context):base(context)
		{
		}
	}
}

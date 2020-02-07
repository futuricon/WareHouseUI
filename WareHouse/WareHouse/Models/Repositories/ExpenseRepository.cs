using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WareHouse.Models.Context;
using WareHouse.Models.DbModels;

namespace WareHouse.Models.Repositories
{
	public interface IExpenseRepository: IGenericRepository<Expense>
	{
		
	}

	public class ExpenseRepository:GenericRepository<Expense>, IExpenseRepository
	{
		//ApplicationDbContext _dbcontext;
		public ExpenseRepository(ApplicationDbContext applicationDb):base(applicationDb){}

	}
}

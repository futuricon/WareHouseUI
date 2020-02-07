using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Models.Context;
using WareHouse.Models.DbModels;

namespace WareHouse.Models.Repositories
{
	public interface IGenericRepository<TEntity>
						where TEntity : class
	{
		IEnumerable<TEntity> GetAllWithInclude<TProperty>(Expression<Func<TEntity, TProperty>> expression);
		IEnumerable<TEntity> GetAllWithInclude<TProperty>
			(Expression<Func<TEntity, TProperty>> f, 
			Expression<Func<TEntity, TProperty>> s);

		IEnumerable<TEntity> GetAll();
		Task<TEntity> GetById(int id);
		Task Create(TEntity entity);
		Task CreateRange(IEnumerable<TEntity> entities);
		Task Update(TEntity entity);
		Task Delete(int id);
	}
	public class GenericRepository<TEntity> : IGenericRepository<TEntity>
	where TEntity : class,IEntity
	{
		ApplicationDbContext _dbContext;
		public GenericRepository(ApplicationDbContext applicationDb)
		{
			_dbContext = applicationDb;
		}

		public async Task Create(TEntity entity)
		{
			await _dbContext.Set<TEntity>().AddAsync(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task CreateRange(IEnumerable<TEntity> entities)
		{
			await _dbContext.Set<TEntity>().AddRangeAsync(entities);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var entity = await GetById(id);
			_dbContext.Set<TEntity>().Remove(entity);
			await _dbContext.SaveChangesAsync();
		}

		public IEnumerable<TEntity> GetAll()
		{
			return _dbContext.Set<TEntity>().AsNoTracking();
		}

		public IEnumerable<TEntity> GetAllWithInclude<TProperty>(Expression<Func<TEntity, TProperty>> expression)
		{
			return _dbContext.Set<TEntity>().Include(expression).AsNoTracking();
		}

		public IEnumerable<TEntity> GetAllWithInclude<TProperty>(Expression<Func<TEntity, TProperty>> f, Expression<Func<TEntity, TProperty>> s)
		{
			return _dbContext.Set<TEntity>().Include(f).Include(s).AsNoTracking();
		}

		public async Task<TEntity> GetById(int id)
		{
			return await _dbContext.Set<TEntity>()
			   .AsNoTracking()
			   .FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task Update(TEntity entity)
		{
			_dbContext.Set<TEntity>().Update(entity);
			await _dbContext.SaveChangesAsync();
		}
	}
}

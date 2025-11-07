
using Health.Application.Interface;
using Health.Domain.Base;
using Health.Persistensce.Context;
using Microsoft.EntityFrameworkCore;

namespace Health.Persistensce.GenericRepository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		#region Crof
		private HealthDbContext _context;
		private DbSet<T> _dbset;

		public GenericRepository(HealthDbContext context, DbSet<T> dbset)
		{
			_context = context;
			_dbset = _context.Set<T>();
		}

		#endregion

		#region Get


		public IQueryable<T?> GetQueryAsync()
		{
			return _dbset.AsQueryable();
		}

		public async Task<T?> GetByIdAsync(Guid id)
		{
			return await _dbset.FindAsync(id);
		}

		public Task GetByCodeAsync(int id)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region AddOrEdit

		public async Task<T> AddAsync(T entity)
		{
			await _dbset.AddAsync(entity);
			return entity;
		}
		public async Task AddRangeEntity(List<T> entities)
		{
			foreach (var entity in entities)
			{
				await AddAsync(entity);
			}
		}

		public Task UpdateAsync(T entity)
		{
			entity.UpdatedOn = DateTime.Now;
			_dbset.Update(entity);
			return Task.CompletedTask;
		}

		#endregion

		#region Delete

		public Task DeleteAsync(T entity)
		{
			entity.IsDeleted = true;
			UpdateAsync(entity);
			return Task.CompletedTask;
		}
		public async Task DeleteAsync(Guid id)
		{
			T entity = await GetByIdAsync(id);
			if (entity != null) DeleteAsync(entity);
		}


		public void DeletePermanent(T entity)
		{
			_dbset.Remove(entity);
		}

		public void DeletePermanentEntities(List<T> entity)
		{
			_context.RemoveRange(entity);
		}

		public async Task DeletePermanent(Guid entityId)
		{
			T entity = await GetByIdAsync(entityId);
			if (entity != null) DeletePermanent(entity);
		}

		#endregion

		
	}
}

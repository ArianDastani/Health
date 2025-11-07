using Health.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace Health.Application.Interface
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		IQueryable<T?> GetQueryAsync();
		Task<T?> GetByIdAsync(Guid id);
		Task GetByCodeAsync(int id);
		Task<T> AddAsync(T entity);
		Task AddRangeEntity(List<T> entities);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
		Task DeleteAsync(Guid id);
		void DeletePermanent(T entity);
		void DeletePermanentEntities(List<T> entity);
		Task DeletePermanent(Guid entityId);



	}


}


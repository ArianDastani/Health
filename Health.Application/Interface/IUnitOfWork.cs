using Health.Domain.Base;

namespace Health.Application.Interface
{
	public interface IUnitOfWork : IAsyncDisposable
	{
		IGenericRepository<T> Repository<T>() where T : BaseEntity;
		Task<int> Save(CancellationToken cancellationToken);
		Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);
		Task BeginTransactionAsync();
		Task CommitTransactionAsync();
		Task RollbackTransactionAsync();
	}
}

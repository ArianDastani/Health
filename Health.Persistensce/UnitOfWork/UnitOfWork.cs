using Health.Application.Interface;
using Health.Domain.Base;
using Health.Persistensce.Context;
using Health.Persistensce.GenericRepository;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;

namespace Health.Persistensce.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		#region ctor

		private HealthDbContext _context;

		//private  Dictionary<Type, object> _repositories;
		private Hashtable _repositories;
		private IDbContextTransaction? _currentTransaction;

		public UnitOfWork(HealthDbContext context)
		{
			_context = _context ?? throw new ArgumentNullException(nameof(_context));
			//_repositories = new Dictionary<Type, object>();
		}

		#endregion

		#region Repository

		public IGenericRepository<T> Repository<T>() where T : BaseEntity
		{
			if (_repositories == null)
				_repositories = new Hashtable();

			var type = typeof(T).Name;

			if (!_repositories.ContainsKey(type))
			{
				var repositoryType = typeof(GenericRepository<>);

				var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);

				_repositories.Add(type, repositoryInstance);
			}

			return (IGenericRepository<T>)_repositories[type];
		}

		#endregion

		#region Transaction

		public async Task BeginTransactionAsync()
		{
			if (_currentTransaction == null)
				_currentTransaction = await _context.Database.BeginTransactionAsync();
		}

		public async Task CommitTransactionAsync()
		{
			try
			{
				await _context.SaveChangesAsync();
				if (_currentTransaction != null)
					await _currentTransaction.CommitAsync();
			}
			catch
			{
				await RollbackTransactionAsync();
				throw;
			}
			finally
			{
				if (_currentTransaction != null)
				{
					await _currentTransaction.DisposeAsync();
					_currentTransaction = null;
				}
			}
		}

		public async Task RollbackTransactionAsync()
		{
			if (_currentTransaction != null)
			{
				await _currentTransaction.RollbackAsync();
				await _currentTransaction.DisposeAsync();
				_currentTransaction = null;
			}
		}

		#endregion

		#region Save

		public async Task<int> Save(CancellationToken cancellationToken)
		{
			return await _context.SaveChangesAsync(cancellationToken);
		}

		public Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Dis

		public ValueTask DisposeAsync()
		{
			_context.Dispose();
			_currentTransaction?.Dispose();
			return ValueTask.CompletedTask;
		}
		#endregion
	}
}


	


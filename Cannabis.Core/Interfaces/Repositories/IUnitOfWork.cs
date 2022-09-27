using Cannabis.Core.Entities;

namespace Cannabis.Core.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    Task<int> Complete();
    
}

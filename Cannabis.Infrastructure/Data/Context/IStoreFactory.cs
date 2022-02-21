namespace Cannabis.Infrastructure.Data.Context;

public interface IStoreFactory : IDisposable
{
    Task<int> SaveChangesAsync();
}
namespace Cannabis.Infrastructure.Data.Context;

public interface IStoreContext: IDisposable, IStoreContextDbSets
{
    Task<int> SaveChangesAsync();
}
namespace Cannabis.Infrastructure.Data.Context;

public partial class StoreFactory : IStoreFactory
{
    private readonly StoreContext _context;

    public StoreFactory(StoreContext context) => _context = context;

    public void Dispose() => _context.Dispose();

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}


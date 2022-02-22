using Cannabis.Core.Interfaces.Repositories;
using Cannabis.Core.Entities;
using Cannabis.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Cannabis.Core.Specifitactions;

namespace Cannabis.Infrastructure.Data.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity

{
    private readonly StoreContext _context;

    public GenericRepository(StoreContext context) => _context = context;

    public async Task<int> CountAsync(ISpecification<T> spec) => await ApplySpec(spec).CountAsync();

    public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

    public async Task<T> GetEntityWithSpec(ISpecification<T> spec) => await ApplySpec(spec).FirstOrDefaultAsync();

    public async Task<IReadOnlyList<T>> ListAllAsync() => await _context.Set<T>().ToListAsync();

    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec) => await ApplySpec(spec).ToArrayAsync();

    private IQueryable<T> ApplySpec(ISpecification<T> spec)
        => SpecifactionEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);

    
}
using Cannabis.Core.Entities;
using Cannabis.Core.Specifitactions;
using Microsoft.EntityFrameworkCore;

namespace Cannabis.Infrastructure.Data.Repositories;

public class SpecifactionEvaluator<TEntity> where TEntity : BaseEntity
{
    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
    {
        var query = inputQuery;
        if(spec.Criteria != null)
        {
            query = query.Where(spec.Criteria);
        }

        query = spec.Includes.Aggregate(query, (current, include) => current.Include(include) );
        return query;
    }
}
    
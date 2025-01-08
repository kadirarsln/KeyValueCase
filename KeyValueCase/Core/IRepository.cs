using System.Linq.Expressions;

namespace KeyValueCase.Core;

public interface IRepository<TEntity, TId> where TEntity : Entity<TId>
{
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task SaveAsync(TEntity entity);
    Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
}


using Marten;
using System.Linq.Expressions;

namespace KeyValueCase.Core
{
    public abstract class RepositoryBase<TEntity, TId>(IDocumentStore documentStore) : IRepository<TEntity, TId>
        where TEntity : Entity<TId>
    {
        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            await using var session = documentStore.LightweightSession();
            return await session.Query<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task SaveAsync(TEntity entity)
        {
            await using var session = documentStore.LightweightSession();
            session.Store(entity);
            await session.SaveChangesAsync();
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            await using var session = documentStore.LightweightSession();
            var entity = await session.Query<TEntity>().FirstOrDefaultAsync(predicate);
            if (entity != null)
            {
                session.Delete(entity);
                await session.SaveChangesAsync();
            }
        }
    }
}
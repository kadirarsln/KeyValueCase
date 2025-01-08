using System.Linq.Expressions;
using KeyValueCase.Models;
using Marten;
using Marten.Internal.Storage;

namespace KeyValueCase.Repositories
{
    public class KeyValueRepository(IDocumentStore documentStore) : IKeyValueRepository
    {
        public async Task<KeyValueModel?> GetAsync(Expression<Func<KeyValueModel, bool>> predicate)
        {
            await using var session = documentStore.LightweightSession();
            return await session.Query<KeyValueModel>().FirstOrDefaultAsync(predicate);
        }

        public async Task SaveAsync(KeyValueModel entity)
        {
            await using var session = documentStore.LightweightSession();
            session.Store(entity);
            await session.SaveChangesAsync();
        }

        public async Task DeleteAsync(Expression<Func<KeyValueModel, bool>> predicate)
        {
            await using var session = documentStore.LightweightSession();
            var entity = await session.Query<KeyValueModel>().FirstOrDefaultAsync(predicate);
            if (entity != null)
            {
                session.Delete(entity);
                await session.SaveChangesAsync();
            }
        }
    }
}

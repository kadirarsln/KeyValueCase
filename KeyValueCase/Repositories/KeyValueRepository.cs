using KeyValueCase.Core;
using KeyValueCase.Models;
using Marten;

namespace KeyValueCase.Repositories;

public class KeyValueRepository(IDocumentStore documentStore)
    : RepositoryBase<KeyValueModel, Guid>(documentStore), IKeyValueRepository
{
}


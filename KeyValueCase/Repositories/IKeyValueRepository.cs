using KeyValueCase.Core;
using KeyValueCase.Models;

namespace KeyValueCase.Repositories;

public interface IKeyValueRepository : IRepository<KeyValueModel, Guid>
{
}


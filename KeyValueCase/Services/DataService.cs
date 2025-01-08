using KeyValueCase.Models;
using KeyValueCase.Repositories;
using Marten;

namespace KeyValueCase.Services;

public class DataService(IKeyValueRepository repository) : IDataService
{
    public async Task<KeyValueModel?> GetDataAsync(string key)
    {
        return await repository.GetAsync(x => x.Key == key);
    }

    public async Task SaveDataAsync(string key, string jsonData)
    {
        var existingItem = await repository.GetAsync(x => x.Key == key);

        if (existingItem != null)
        {
            existingItem.Data = jsonData;
            existingItem.UpdatedDate = DateTime.UtcNow;
            await repository.SaveAsync(existingItem);
        }
        else
        {
            var newItem = new KeyValueModel
            {
                Id = Guid.NewGuid(),
                Key = key,
                Data = jsonData,
                CreatedDate = DateTime.UtcNow
            };
            await repository.SaveAsync(newItem);
        }
    }


    public async Task DeleteDataAsync(string key)
    {
        await repository.DeleteAsync(x => x.Key == key);
    }
}
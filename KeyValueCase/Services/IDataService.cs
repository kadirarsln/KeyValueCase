using KeyValueCase.Models;

namespace KeyValueCase.Services;
public interface IDataService
{
    Task<KeyValueModel?> GetDataAsync(string key);
    Task SaveDataAsync(string key, string jsonData);
    Task DeleteDataAsync(string key);
}

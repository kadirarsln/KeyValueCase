using KeyValueCase.Core;

namespace KeyValueCase.Models;
public sealed class KeyValueModel : Entity<Guid>
{
    public string Key { get; set; } = string.Empty;
    public string Data { get; set; } = string.Empty;
}

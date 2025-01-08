namespace KeyValueCase.Core;
public abstract class Entity<TId>
{
    public TId Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

}

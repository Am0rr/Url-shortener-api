namespace US.DAL.Entities;

public abstract class BaseEntity
{
    public int Id { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; private set; }

    protected void MarkUpdated()
    {
        UpdatedAt = DateTimeOffset.UtcNow;
    }
}
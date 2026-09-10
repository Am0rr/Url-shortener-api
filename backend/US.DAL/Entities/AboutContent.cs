namespace US.DAL.Entities;

public class AboutContent : BaseEntity
{
    public string Text { get; private set; } = null!;
    public int LastModifiedByUserId { get; private set; }
    public User? LastModifiedBy { get; private set; }
    
    protected AboutContent() {}

    public AboutContent(string text, int lastModifiedByUserId)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("Text cannot be empty", nameof(text));

        Text = text;
        LastModifiedByUserId = lastModifiedByUserId;
    }
}
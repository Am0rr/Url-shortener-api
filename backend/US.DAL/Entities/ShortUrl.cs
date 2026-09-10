namespace US.DAL.Entities;

public class ShortUrl : BaseEntity
{
    public string OriginalUrl { get; private set; } = null!;
    public int CreatedByUserId { get; private set; }
    public User? CreatedBy { get; private set; }
    public int ClickCount { get; private set; }
    
    protected ShortUrl() {}

    public ShortUrl(string originalUrl, int createdByUserId)
    {
        if(string.IsNullOrWhiteSpace(originalUrl))
            throw new ArgumentException("URL cannot be empty", nameof(originalUrl));
        
        if(!Uri.TryCreate(originalUrl, UriKind.Absolute, out _))
            throw new ArgumentException("Invalid URL format", nameof(originalUrl));

        OriginalUrl = originalUrl;
        CreatedByUserId = createdByUserId;
        ClickCount = 0;
    }
    
    public void RegisterClick()
    {
        ClickCount++;
        MarkUpdated();
    }
}
using US.DAL.Enums;

namespace US.DAL.Entities;

public class User : BaseEntity
{
    public string Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public UserRole Role { get; private set; }
    
    protected User() {}

    public User(string email, string passwordHash, UserRole role = UserRole.User)
    {
        if (string.IsNullOrWhiteSpace((email)))
            throw new ArgumentException("Email cannot be empty.", nameof(email));

        if (!IsValidEmail(email))
            throw new ArgumentException("Invalid email format.", nameof(email));
        
        if (string.IsNullOrWhiteSpace((passwordHash)))
            throw new ArgumentException("Password hash cannot be empty.", nameof(passwordHash));
        
        Email = email.Trim().ToLowerInvariant();
        PasswordHash = passwordHash;
        Role = role;
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}
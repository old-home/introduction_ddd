namespace Web.Domain.User;

public class User(string emailAddress, string password): IEquatable<User>
{
    public UserId UserId { get; init; } = new();
    public EmailAddress EmailAddress { get; private set; } = new EmailAddress(emailAddress);
    public string Password { get; private set; } = password;

    public bool Equals(User? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return UserId.Equals(other.UserId);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((User)obj);
    }

    public override int GetHashCode()
    {
        return UserId.GetHashCode();
    }
}
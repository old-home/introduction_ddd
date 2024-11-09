namespace Web.Domain.User;

public class User(string emailAddress, string password, UserId? userId = null): IEquatable<User>
{
    public UserId UserId { get; init; } = userId ?? new UserId();
    public EmailAddress EmailAddress { get; private set; } = new EmailAddress(emailAddress);
    public Password Password { get; private set; } = new Password(password);

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
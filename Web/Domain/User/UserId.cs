namespace Web.Domain.User;

public class UserId: IEquatable<UserId>
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public bool Equals(UserId? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((UserId)obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
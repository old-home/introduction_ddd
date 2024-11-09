namespace Web.Domain.User;

public class Password(string value): IEquatable<Password>
{
    public string Value { get; init; } = value;
    public bool Equals(Password? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value == other.Value;
    }
}
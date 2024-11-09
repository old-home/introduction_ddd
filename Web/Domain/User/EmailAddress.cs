using System.Globalization;
using System.Text.RegularExpressions;

namespace Web.Domain.User;

public class EmailAddress: IEquatable<EmailAddress>
{
    public string Value { get; }
    
    public EmailAddress(string value)
    {
        if (IsValidEmail(value))
        {
            Value = value;
        }
        else
        {
            throw new ArgumentException($"Invalid email address {value}", nameof(value));
        }
    }
    
    private static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }

        try
        {
            email = Regex.Replace(
                email,
                "(@)(.+)$",
                DomainMapper,
                RegexOptions.None,
                TimeSpan.FromMilliseconds(200)
            );

            string DomainMapper(Match match)
            {
                var idn = new IdnMapping();
                var domainName = idn.GetAscii(match.Groups[2].Value);
                Console.WriteLine(domainName);
                return match.Groups[1].Value + domainName;
            }
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
        catch (ArgumentException)
        {
            return false;
        }

        try
        {
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    public bool Equals(EmailAddress? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((EmailAddress)obj);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}
using Web.Domain.User;

namespace Web.Tests.Domain.User;

[TestFixture]
public class PasswordTest
{
    [Test]
    public void ConstructorTest()
    {
        var password = new Password("password");
        var password2 = new Password("password");
        Assert.That(password, Is.EqualTo(password2));
    }
}
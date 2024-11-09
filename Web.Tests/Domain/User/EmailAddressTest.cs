using Web.Domain.User;

namespace Web.Tests.Domain.User;

[TestFixture]
public class EmailAddressTest
{
    [Test, Category("Task1-1")]
    public void ConstructorTest()
    {
        var emailAddress = new EmailAddress("taira.terashima@gmail.com");
        Assert.That(emailAddress.Value, Is.EqualTo("taira.terashima@gmail.com"));
    }

    [Test, Category("Task1-1")]
    public void ConstructorInvalidTest()
    {
        Assert.That(
            () =>
            {
                var emailAddress = new EmailAddress("taira.terashima");
                Console.WriteLine(emailAddress.Value);
            },
            Throws.ArgumentException
        );
    }

    [Test, Category("Task1-1"), Category("Task1-2")]
    public void EqualityTest()
    {
        var emailAddress1 = new EmailAddress("taira.terashima@gmail.com");
        var emailAddress2 = new EmailAddress("taira.terashima@gmail.com");
        var emailAddress3 = new EmailAddress("hiromu.terashima@gmail.com");
        Assert.That(emailAddress1, Is.EqualTo(emailAddress2));
        Assert.That(emailAddress1, Is.Not.EqualTo(emailAddress3));
        Assert.That(emailAddress2, Is.Not.EqualTo(emailAddress3));
    }
}
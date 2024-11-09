using Web.Domain.User;

namespace Web.Tests.Domain.User;

[TestFixture]
public class EmailAddressTest
{
    [
        Test,
        TestCase("abcdcefghijklmnopqrstuvwxyz.ABCDEFGHIJKLMNOPQRSTUVWXYZ.123456789@example.com"),
        TestCase("taira.terashima@gmail.com"),
        TestCase("abcdcefghijklmnopqrstuvwxyz.ABCDEFGHIJKLMNOPQRSTUVWXYZ.123456789@abcdefgh.co.jp"),
        TestCase("abcdcefghijklmnopqrstuvwxyz.ABCDEFGHIJKLMNOPQRSTUVWXYZ.123456789@hellograywings.com"),
        Category("Task2-1"),
        Category("Task2-2"),
        Category("Task2-3"),
        Category("Task3-1")
        
    ]
    public void ConstructorTest(string emailAddress)
    {
        var emailAddressObject = new EmailAddress(emailAddress);
        Assert.That(emailAddressObject.Value, Is.EqualTo(emailAddress));
    }

    [
        Test,
        Category("Task2-1"),
        Category("Task2-2"),
        Category("Task2-3"),
        Category("Task3-1")
    ]
    public void CantChangeEmailAddressTest()
    {
        var propertyInfo = typeof(EmailAddress).GetProperty(nameof(EmailAddress.Value));
        Assert.That(propertyInfo != null && propertyInfo.CanWrite, Is.False);
    }

    [
        Test,
        Category("Task2-2"),
        Category("Task2-3"),
        Category("Task3-1")
    ]
    public void ConstructorInvalidTest()
    {
        Assert.That(() =>
        {
            var emailAddress = new EmailAddress("taira.terashima");
            Console.WriteLine(emailAddress.Value);
        }, Throws.ArgumentException);
    }

    [
        Test,
        Category("Task2-1"),
        Category("Task2-2"),
        Category("Task2-3"),
        Category("Task3-1")
    ]
    public void IEquatableTest()
    {
        Assert.That(typeof(EmailAddress).GetInterfaces().Contains(typeof(IEquatable<EmailAddress>)), Is.True);
    }
    
    [
        Test,
        Category("Task2-1"),
        Category("Task2-2"),
        Category("Task2-3"),
        Category("Task3-1")
    ]
    public void EqualityTest()
    {
        var emailAddress1 = new EmailAddress("taira.terashima@gmail.com");
        var emailAddress2 = new EmailAddress("taira.terashima@gmail.com");
        var emailAddress3 = new EmailAddress("hiromu.terashima@gmail.com");
        Assert.Multiple(() =>
        {
            Assert.That(emailAddress1, Is.EqualTo(emailAddress2));
            Assert.That(emailAddress1, Is.Not.EqualTo(emailAddress3));
            Assert.That(emailAddress2, Is.Not.EqualTo(emailAddress3));
        });
    }
}
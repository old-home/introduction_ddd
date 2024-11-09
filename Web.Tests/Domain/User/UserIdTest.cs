using Web.Domain.User;

namespace Web.Tests.Domain.User;

[TestFixture]
public class UserIdTest
{
    [
        Test,
        Category("Task3-1"),
        Category("Task3-2")
    ]
    public void ValueTest()
    {
        var userId = new UserId();
        Assert.That(userId.Id.ToString().Length, Is.EqualTo(36));
    }

    [
        Test,
        Category("Task3-2")
    ]
    public void EqualityTest()
    {
        var userId1 = new UserId();
        Assert.That(userId1 == userId1, Is.True);
    }
}
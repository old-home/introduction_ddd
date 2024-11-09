using Web.Domain.User;

namespace Web.Tests.Domain.User;

[TestFixture]
public class UserTest
{
    [Test]
    public void UserEqualityTest()
    {
        var userId1 = new UserId();
        var user1 = new Web.Domain.User.User(
            "email@email.com",
            "password",
            userId1
        );
    }
}
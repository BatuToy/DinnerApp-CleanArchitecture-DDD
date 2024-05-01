using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.OldUser;

namespace BuberDinner.Infrastructre.Persistence;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        var user = _users.SingleOrDefault(u => u.Email == email);
        return(user);
    }
}

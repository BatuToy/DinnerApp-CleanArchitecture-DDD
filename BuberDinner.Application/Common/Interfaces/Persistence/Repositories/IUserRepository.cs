using BuberDinner.Domain.OldUser;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IUserRepository 
{
    User? GetUserByEmail(string email);
    void Add(User user);
}
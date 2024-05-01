using BuberDinner.Domain.OldUser;

namespace BuberDinner.Application.Common.Intefaces.Authentication;

public interface IJwtTokenGenerator 
{
    string GenerateToken(User user);
}
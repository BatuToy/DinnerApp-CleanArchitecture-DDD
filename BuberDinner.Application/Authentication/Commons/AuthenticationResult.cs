using BuberDinner.Domain.OldUser;

namespace BuberDinner.Application.Authentication.Commons;

public record AuthenticationResult(
    User User ,
    string Token 
);

using BuberDinner.Application.Common.Intefaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Authentication.Commons;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.OldUser;
using ErrorOr;
using MediatR;


namespace BuberDinner.Application.Authentication.Queries.Login;
public class LoginQueryHandler : IRequestHandler<LoginQuery , ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public LoginQueryHandler(IUserRepository userRepository , IJwtTokenGenerator jwtTokenGenerator)

    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        //Validate the User already exists 
        if(_userRepository.GetUserByEmail(query.Email) is not User user)
            return Errors.Authentication.InvalidCredentials;
        //Validate the password is Correct 
        if(user.Password != query.Password)
        {   
            return  Errors.Authentication.InvalidCredentials;
        }
        //Create a JWT token        
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user ,
            token); 
    } 
}
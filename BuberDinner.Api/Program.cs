using BuberDinner.Api;
using BuberDinner.Application;
using BuberDinner.Infrastructre;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();

{
    // this approach is taken by Amich and the dude suggest this approach Global Handling Exceptions . This approach routes
    // the throwen exception on the error controller by routing in program.cs and handling by ./BuberDinner.Api.Common.Errors.
    // BuberDinnerProblemDetailsFactory.cs class and returning to the client .
    app.UseExceptionHandler("/error");
   
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

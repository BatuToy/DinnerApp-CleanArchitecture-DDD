using BuberDinner.Api.Common.Http;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Authorize]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.All(e => e.Type == ErrorType.Validation))
        {
            return ValidationProblem(errors);
        }

        var firstError = errors[0];

        // Add errors to HttpContext.Items so that they can be logged
        HttpContext.Items.Add(HttpContextItemKey.Errors, errors);

        return Problem(firstError);

    }

    private IActionResult Problem(Error firstError)
    {
        var statusCode = firstError.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(title: firstError.Description, statusCode: statusCode);
    }

    private IActionResult ValidationProblem(List<Error> errors)
    {
        var modelStateDictinoary = new ModelStateDictionary();
        foreach (var error in errors)
        {
            modelStateDictinoary.AddModelError(error.Code, error.Description);
        }
        return ValidationProblem(modelStateDictinoary);

    }
}

//if (errors.All(e => e.Type == ErrorType.Validation))
//{return ValidationProblem(errors);}
//        
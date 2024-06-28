using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
public abstract class ApiController<T> : ControllerBase
{
    private ISender _sender;

    protected ISender Sender => _sender ??= HttpContext.RequestServices.GetService<ISender>();

    private readonly ICollection<string> _errors = new List<string>();

    protected ActionResult CustomResponse(object? result = null)
    {
        if (IsOperationValid())
        {
            return Ok(result);
        }

        return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
        {
            { "Messages", _errors.ToArray() }
        }));
    }

    protected ActionResult CustomResponse(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            AddError(error.ErrorMessage);
        }

        return CustomResponse(result: validationResult);
    }

    protected bool IsOperationValid()
    {
        return !_errors.Any();
    }

    protected void AddError(string erro)
    {
        _errors.Add(erro);
    }

    protected void ClearErrors()
    {
        _errors.Clear();
    }
}

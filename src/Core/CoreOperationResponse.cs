using FluentValidation.Results;
using System.Text.Json;

namespace Core;

public class CoreOperationResponse : ValidationResult
{
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }

    public void AddError(string errorMessage)
    {
        Errors.Add(new ValidationFailure("error", errorMessage));
    }    
}

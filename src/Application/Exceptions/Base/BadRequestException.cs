using Application.Core.Contract;

namespace Application.Exceptions.Base;

public abstract class BadRequestException : CoreOperationResponse
{
    protected BadRequestException(string code, string message)
    {
        AddError(code, message);
    }
}
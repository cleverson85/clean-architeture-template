using Application.Core.Contract;

namespace Application.Exceptions.Base;

public abstract class NotFoundException : CoreOperationResponse
{
    protected NotFoundException(string code, string message)
    {
        AddError(code, message);
    }
}
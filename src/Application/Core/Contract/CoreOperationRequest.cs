using Application.Interfaces.Messaging;
using System.Text.Json;

namespace Application.Core.Contract;

public class CoreOperationRequest : ICommand<CoreOperationResponse>
{
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}

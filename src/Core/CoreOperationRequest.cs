using System.Text.Json;

namespace Core;

public class CoreOperationRequest
{
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}

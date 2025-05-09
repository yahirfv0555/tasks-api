using System.Text.Json;

namespace earrings_api.Handlers
{
    public class JsonNamingPolicyHandler : JsonNamingPolicy
    {
        public override string ConvertName(string name) =>
            name.ToLower();
    }
}

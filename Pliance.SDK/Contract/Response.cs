using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pliance.SDK.Contract
{
    public abstract class Response<T> : Response
    {
        public T Data { get; set; }
    }

    public abstract class Response
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ResponseStatus Status { get; set; }
        public bool Success => Status == ResponseStatus.Success;
        public string Message { get; set; }
        public string Checkpoint { get; set; }
    }
}

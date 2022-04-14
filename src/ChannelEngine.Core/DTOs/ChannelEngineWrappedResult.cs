using Newtonsoft.Json;

namespace ChannelEngine.Core.DTOs;
public class ChannelEngineWrappedResult<T> where T : class
{
    [JsonProperty("Content")]
    public T Content { get; set; }

    [JsonProperty("StatusCode")]
    public long StatusCode { get; set; }

    [JsonProperty("LogId")]
    public object LogId { get; set; }

    [JsonProperty("Success")]
    public bool Success { get; set; }

    [JsonProperty("Message")]
    public string Message { get; set; }

    [JsonProperty("ValidationErrors")]
    public ValidationErrors ValidationErrors { get; set; }
}

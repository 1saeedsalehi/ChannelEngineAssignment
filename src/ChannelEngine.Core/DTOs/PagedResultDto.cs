using System.Text.Json.Serialization;
using ChannelEngine.Core.Exceptions;

namespace ChannelEngine.Core.DTOs;
public class PagedResultDto<T> where T : class
{
    [JsonPropertyName("Content")]
    public List<T> Content { get; set; }

    [JsonPropertyName("Count")]
    public int Count { get; set; }

    [JsonPropertyName("TotalCount")]
    public int TotalCount { get; set; }

    [JsonPropertyName("ItemsPerPage")]
    public int ItemsPerPage { get; set; }

    [JsonPropertyName("StatusCode")]
    public int StatusCode { get; set; }

    [JsonPropertyName("LogId")]
    public object LogId { get; set; }

    [JsonPropertyName("Success")]
    public bool Success { get; set; }

    [JsonPropertyName("Message")]
    public object Message { get; set; }

    public bool NextPage() => Success && TotalCount > ItemsPerPage && Count == ItemsPerPage;

    public void EnsureSuccess()
    {
        if (!Success)
        {
            throw new ChannelEngineException($"{StatusCode}, {Message} - log id {LogId}");
        }
    }
}

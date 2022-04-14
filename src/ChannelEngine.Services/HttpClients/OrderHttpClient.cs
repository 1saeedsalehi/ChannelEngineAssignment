using ChannelEngine.Core;
using ChannelEngine.Core.DTOs;
using ChannelEngine.Core.Exceptions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ChannelEngine.Services.HttpClients;
public class OrderHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly Settings _settings;

    public OrderHttpClient(HttpClient httpClient, IOptions<Settings> options)
    {
        _httpClient = httpClient;
        _settings = options.Value;
    }

    /// <summary>
    /// http client for getting all in progress orders
    /// </summary>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    /// <exception cref="ChannelEngineException"></exception>
    internal async Task<OrderDto?> GetAllInProgressOrdersAsync(CancellationToken cancellation)
    {
        var httpResponse = await _httpClient.GetAsync($"/api/v2/orders?statuses=IN_PROGRESS&apikey={_settings.ChannelEngine.ApiKey}", cancellation);

        httpResponse.EnsureSuccessStatusCode();

        var result = await httpResponse.Content.ReadAsStringAsync(cancellation);

        var serialized = JsonConvert.DeserializeObject<OrderDto>(result);

        return serialized is not null && serialized.Success
            ? serialized
            : throw new ChannelEngineException("There is an issue with getting orders");

    }



}

using System.Net.Http.Json;
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
    internal async Task<IEnumerable<Orders>> GetAllInProgressOrdersAsync(CancellationToken cancellation)
    {
        //TODO: move api key to better place ! DRY
        var httpResponse = await _httpClient.GetAsync($"/api/v2/orders?statuses=IN_PROGRESS&apikey={_settings.ChannelEngine.ApiKey}", cancellation);

        httpResponse.EnsureSuccessStatusCode();

        var result = await httpResponse.Content.ReadAsStringAsync(cancellation);

        var serialized = JsonConvert.DeserializeObject<OrderDto>(result);

        return serialized is not null && serialized.Success
            ? serialized.Orders
            : throw new ChannelEngineException("There is an issue with getting orders");

    }

    /// <summary>
    /// http client for updating stock for a product
    /// </summary>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    /// <exception cref="ChannelEngineException"></exception>
    internal async ValueTask<string> UpdateStock(UpdateStockDto input, CancellationToken cancellation)
    {
        //TODO: move api key to better place ! DRY
        var httpResponse = await _httpClient.PutAsJsonAsync($"/api/v2/offer/stock?apikey={_settings.ChannelEngine.ApiKey}"
            ,input,
            cancellation);

        httpResponse.EnsureSuccessStatusCode();

        var result = await httpResponse.Content.ReadAsStringAsync(cancellation);

        var serialized = JsonConvert.DeserializeObject<ChannelEngineWrappedResult<object>>(result);

        return serialized is not null ? serialized.Message : string.Empty;
    }



}

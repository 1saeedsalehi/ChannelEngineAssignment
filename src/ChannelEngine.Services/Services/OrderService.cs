using AutoMapper;
using ChannelEngine.Core.Exceptions;
using ChannelEngine.Services.HttpClients;

namespace ChannelEngine.Services.Services;
public class OrderService
{
    private readonly IMapper _mapper;
    private readonly OrderHttpClient _orderHttpClient;

    public OrderService(IMapper mapper,
        OrderHttpClient orderHttpClient)
    {
        _mapper = mapper;
        _orderHttpClient = orderHttpClient;
    }

    /// <summary>
    /// Sample method!
    /// </summary>
    /// <returns></returns>
    public string Ping(string input)
    {
        return input.Equals("ping", StringComparison.InvariantCultureIgnoreCase)
            ? "pong!"
            : throw new ChannelEngineException("invalid parameter!");

    }

    public async Task FetchAllInProgressOrdersAsync(CancellationToken stoppingToken)
    {
        await _orderHttpClient.GetAllOrdersAsync(stoppingToken);
    }
}

using AutoMapper;
using ChannelEngine.Core.DTOs;
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
    /// Returns all in progress orders
    /// </summary>
    /// <param name="stoppingToken"></param>
    /// <returns></returns>
    public async Task<OrderDto?> GetAllInProgressOrdersAsync(CancellationToken stoppingToken)
    {
        return await _orderHttpClient.GetAllInProgressOrdersAsync(stoppingToken);
    }

    /// <summary>
    /// Returns top 5 sold iteam based on orders
    /// </summary>
    /// <param name="stoppingToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<TopSoldDto>> GetTopSoldProducts(CancellationToken stoppingToken)
    {
        var orders = await _orderHttpClient.GetAllInProgressOrdersAsync(stoppingToken);

        var topsold = orders.Content
            .SelectMany(order => order.Lines)
            .GroupBy(line => line.Description)
            .Select(groupped => new TopSoldDto
            {
                ProductName = groupped.Key,
                TotalQuantity = groupped.Sum(x => x.Quantity),
                GTIN = groupped.Select(x=>x.Gtin).FirstOrDefault(),
            })
            .OrderByDescending(x => x.TotalQuantity)
            .Take(5)
            .AsEnumerable();

        return topsold;
    }
}

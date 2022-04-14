using AutoMapper;
using ChannelEngine.Core.DTOs;
using ChannelEngine.Services.HttpClients;

namespace ChannelEngine.Services.Services;
public class OrderService
{
    private readonly OrderHttpClient _orderHttpClient;

    public OrderService(OrderHttpClient orderHttpClient)
    {
        _orderHttpClient = orderHttpClient;
    }

    /// <summary>
    /// Returns all in progress orders
    /// </summary>
    /// <param name="stoppingToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Orders>> GetAllInProgressOrdersAsync(CancellationToken stoppingToken = default)
    {
        return await _orderHttpClient.GetAllInProgressOrdersAsync(stoppingToken);
    }

    /// <summary>
    /// Returns top 5 sold iteam based on orders
    /// </summary>
    /// <param name="stoppingToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<TopSoldDto>> GetTopSoldProducts(CancellationToken cancellationToken=default)
    {
        var orders = await _orderHttpClient.GetAllInProgressOrdersAsync(cancellationToken);

        var topsold = orders
            .SelectMany(order => order.Lines)
            .GroupBy(line => line.Description)
            .Select(groupped => new TopSoldDto
            {
                ProductName = groupped.Key,
                TotalQuantity = groupped.Sum(x => x.Quantity),
                GTIN = groupped.Select(x => x.Gtin).FirstOrDefault(),
            })
            .OrderByDescending(x => x.TotalQuantity)
            .Take(5)
            .AsEnumerable();

        return topsold;
    }

    /// <summary>
    /// Updates stock for specified product
    /// </summary>
    /// <param name="stoppingToken"></param>
    /// <returns></returns>
    public async ValueTask<string> UpdateStock(string productNo, CancellationToken stoppingToken=default)
    {
        var result = await _orderHttpClient.UpdateStock(new UpdateStockDto
        {
            MerchantProductNo = productNo,
            Stock = 25,
        }, stoppingToken);

        return result;
    }
}

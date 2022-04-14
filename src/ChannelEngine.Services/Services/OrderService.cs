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
    public async Task<IEnumerable<OrderDto>> GetAllInProgressOrdersAsync(CancellationToken stoppingToken = default)
    {
        return await _orderHttpClient.GetAllInProgressOrdersAsync(stoppingToken);
    }

    /// <summary>
    /// Returns top 5 sold iteam based on orders
    /// </summary>
    /// <param name="stoppingToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<ProductDto>> GetTopSoldProducts(int count = 5, CancellationToken cancellationToken = default)
    {
        //We don't need call this again - this method can be an extension method for Orders! 
        //TODO: fix it later!

        var orders = await _orderHttpClient.GetAllInProgressOrdersAsync(cancellationToken);

        var topsold = orders
            .SelectMany(order => order.Lines)
            .GroupBy(line => line.Description)
            .Select(groupped => new ProductDto
            {
                ProductName = groupped.Key,
                TotalQuantity = groupped.Sum(x => x.Quantity),
                GTIN = groupped.Select(x => x.Gtin).FirstOrDefault(),
                MerchantProductNo = groupped.Select(x => x.MerchantProductNo).FirstOrDefault(),
            })
            .OrderByDescending(x => x.TotalQuantity)
            .Take(count)
            .AsEnumerable();

        return topsold;
    }

    /// <summary>
    /// Updates stock for specified product
    /// </summary>
    /// <param name="stoppingToken"></param>
    /// <returns></returns>
    public async ValueTask<string> UpdateStock(string productNo, CancellationToken stoppingToken = default)
    {
        var result = await _orderHttpClient.UpdateStock(new UpdateStockDto
        {
            MerchantProductNo = productNo,
            Stock = 25,
        }, stoppingToken);

        return result;
    }
}

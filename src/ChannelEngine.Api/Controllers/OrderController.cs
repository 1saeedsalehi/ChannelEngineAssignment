using ChannelEngine.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChannelEngine.Api.Controllers;

public class OrderController : ApiControllerBase
{
    private readonly OrderService _orderService;


    public OrderController(OrderService orderService) => _orderService = orderService;

    /// <summary>
    /// Get All In Progress Orders
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAllInProgressOrders(CancellationToken cancellationToken)
    {
        var result = await _orderService.GetAllInProgressOrdersAsync(cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Get Top 5 Sold items
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("Top-Sold")]
    public async Task<IActionResult> GetTopSoldProducts(CancellationToken cancellationToken)
    {
        var result = await _orderService.GetTopSoldProducts(cancellationToken: cancellationToken);

        return Ok(result);
    }


    /// <summary>
    /// Will update stock to 25
    /// </summary>
    /// <param name="productNo"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch("Update-Stock")]
    public async Task<IActionResult> UpdateStock(string productNo, CancellationToken cancellationToken)
    {

        if (string.IsNullOrWhiteSpace(productNo))
        {
            throw new ArgumentNullException(nameof(productNo));
        }

        var result = await _orderService.UpdateStock(productNo, cancellationToken);

        return Ok(result);
    }
}

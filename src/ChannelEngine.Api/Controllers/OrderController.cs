using ChannelEngine.Core;
using ChannelEngine.Services.HttpClients;
using ChannelEngine.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ChannelEngine.Api.Controllers;

public class OrderController : ApiControllerBase
{
    private readonly OrderService _orderService;
    private readonly ILogger<OrderController> _logger;

    public OrderController(
        OrderService orderService,
        ILogger<OrderController> logger)
    {
        _orderService = orderService;
        _logger = logger;
    }

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
        var result = await _orderService.GetTopSoldProducts(cancellationToken);

        return Ok(result);
    }

}

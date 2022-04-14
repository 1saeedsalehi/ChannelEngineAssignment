using ChannelEngine.Core;
using ChannelEngine.Services.HttpClients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ChannelEngine.Api.Controllers;

public class OrderController : ApiControllerBase
{
    private readonly OrderHttpClient _orderHttpClient;
    private readonly ILogger<OrderController> _logger;

    public OrderController(
        OrderHttpClient orderHttpClient,
        IOptions<Settings> options,
        ILogger<OrderController> logger)
    {
        _orderHttpClient = orderHttpClient;
        _logger = logger;
    }
    /// <summary>
    /// Get All In Progress Orders
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> InProgressOrders(CancellationToken cancellationToken)
    {
        var result = await _orderHttpClient.GetAllOrdersAsync(cancellationToken);

        return Ok(result);
    }
}

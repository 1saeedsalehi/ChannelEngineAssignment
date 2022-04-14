using AutoMapper;
using ChannelEngine.Api.DTOS;
using ChannelEngine.Core;
using ChannelEngine.Core.DTOs;
using ChannelEngine.Services.HttpClients;
using ChannelEngine.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ChannelEngine.Api.Controllers;

public class OrderController : ApiControllerBase
{
    private readonly OrderService _orderService;
    private readonly IMapper _mapper;
    private readonly ILogger<OrderController> _logger;


    public OrderController(
        OrderService orderService,
        IMapper mapper,
        ILogger<OrderController> logger)
    {
        _orderService = orderService;
        _mapper = mapper;
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

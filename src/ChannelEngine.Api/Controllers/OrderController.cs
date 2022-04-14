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
    /// <param name="input"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch("Update-Stock")]
    public async Task<IActionResult> UpdateStock(UpdateStockInputDto input, CancellationToken cancellationToken)
    {
        if (input is null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        var mapped = _mapper.Map<UpdateStockDto>(input);

        var result = await _orderService.UpdateStock(mapped, cancellationToken);

        return Ok(result);
    }
}

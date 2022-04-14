using System.Diagnostics;
using ChannelEngine.Api.Models;
using ChannelEngine.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChannelEngine.Api.Controllers;

public class HomeController : BaseController
{
    private readonly OrderService _orderService;

    public HomeController(OrderService orderService,
        ILogger<HomeController> logger) : base(logger)
        => _orderService = orderService;

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var orders = await _orderService.GetAllInProgressOrdersAsync(cancellationToken);
        //TODO: we don't need additional call here!
        var topSoldItems = await _orderService.GetTopSoldProducts(cancellationToken: cancellationToken);

        return View(new OrdersViewModel()
        {
            Orders = orders.ToList(),
            TopSoldProducts = topSoldItems.ToList(),
        });
    }

    [HttpPost]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public async Task<IActionResult> UpdateStock(string product)
    {
        var result = await _orderService.UpdateStock(product);

        return new JsonResult(result);
    }

    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

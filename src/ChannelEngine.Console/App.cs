using ChannelEngine.Core;
using ChannelEngine.Core.DTOs;
using ChannelEngine.Services.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

public class App
{
    private readonly ILogger<App> _logger;
    private readonly OrderService _orderService;
    private readonly Settings _appSettings;

    public App(IOptions<Settings> appSettings,
        ILogger<App> logger,
        OrderService orderService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _orderService = orderService;
        _appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
    }

    public async Task Run(string[] args)
    {
        _logger.LogInformation("Starting...");

        Console.WriteLine();
        Console.WriteLine($"Api Key {_appSettings.ChannelEngine.ApiKey}");

        await GetAllOrders();

        await Top5Products();
        
        await UpdateStock();

        _logger.LogInformation("Finished!");
        await Task.CompletedTask;
    }


    private async Task UpdateStock()
    {
        Console.Write($"{Environment.NewLine} Please enter the product no: ");
        var productNo = Console.ReadLine();

        //TODO: validate productNo

        Console.Write($"{Environment.NewLine} Please enter the new stock quantity: ");
        var quantity = int.Parse(Console.ReadLine());

        // TODO: validate quantity

        var result = await _orderService.UpdateStock(productNo).ConfigureAwait(false);

        Console.Write($"{Environment.NewLine} Product stock updated ({result})");
    }


    private async Task Top5Products()
    {
        Console.WriteLine("Getting Top 5 Sold products!");

        var result = await _orderService.GetTopSoldProducts().ConfigureAwait(false);

        var serialzied = JsonConvert.SerializeObject(result);
        Console.WriteLine(serialzied);
    }

    private async Task<IEnumerable<Orders>> GetAllOrders()
    {
        Console.WriteLine("Getting all IN_PROGRESS products");
        var result = await _orderService.GetAllInProgressOrdersAsync().ConfigureAwait(false);

        Console.WriteLine($"Orders count : {result.Count()}");

        var serialzied = JsonConvert.SerializeObject(result);
        Console.WriteLine(serialzied);

        return result;
    }
}
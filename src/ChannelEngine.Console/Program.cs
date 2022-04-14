namespace ChannelEngine.Console;

using System.IO;
using System.Threading.Tasks;
using ChannelEngine.Services.HttpClients;
using ChannelEngine.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

internal class Program
{
    public static async Task Main(string[] args)
    {
        // create service collection
        var services = new ServiceCollection();
        ConfigureServices(services);

        // create service provider
        var serviceProvider = services.BuildServiceProvider();

        // entry to run app
        await serviceProvider.GetService<App>().Run(args);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // configure logging
        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.AddDebug();
        });

        // build config
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();


        // add services:

        // add app
        services.AddTransient<App>();
        //Register Services in DI
        services.AddTransient<OrderService>();

        //services.AddHttpClient<OrderHttpClient>(client =>
        //{
        //    client.BaseAddress = new Uri(Configuration["ChannelEngine:BaseUrl"]);
        //});
    }
}


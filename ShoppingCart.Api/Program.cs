using Serilog;
using ShoppingCart.Api;

CreateHostBuilder(args).Build().Run();


static IHostBuilder CreateHostBuilder(string[] args)
{
    var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/ShoppingCart_Api_Log.txt", rollingInterval: RollingInterval.Infinite)
    .MinimumLevel.Verbose()
    .CreateLogger();

    var builder = Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
        webBuilder.ConfigureLogging(logging =>
        {
            logging.ClearProviders();
            logging.AddSerilog(logger);
        });        
    });

    return builder;
}
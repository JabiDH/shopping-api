using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using ShoppingCart.Api;
using Serilog;
using Microsoft.Extensions.Logging;

namespace ShoppingCart.Test.IntegrationTests
{
    public class ApiTestFixture : IDisposable
    {
        private TestServer _server;
        public HttpClient Client { private set;  get; }

        public ApiTestFixture()
        {
            ConfigureTestServerAndClient();
        }

        private void ConfigureTestServerAndClient()
        {
            var logger = new LoggerConfiguration()                
                .WriteTo.File("Logs/ShoppingCart_Api_Test_Log.txt", rollingInterval: RollingInterval.Infinite)
                .MinimumLevel.Warning()
                .CreateLogger();

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Test.json")
                .Build();

            _server = new TestServer(new WebHostBuilder()
                .UseConfiguration(config)
                .ConfigureLogging(logging => {
                    logging.ClearProviders();
                    logging.AddSerilog(logger);
                })
                .UseStartup<Startup>());
                
            Client = _server.CreateClient();
        }

        public void Dispose()
        {
            // Dispose the test server and HttpClient
            _server.Dispose();
            Client.Dispose();
        }
    }
}

using HomeWorkExample.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace HomeWorkExample.IntegrationTests.Tools;

public class CustomWebFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var customerProvider = services.SingleOrDefault(item => item.ServiceType == typeof(ICalculator));
            services.Remove(customerProvider!);

            services.AddScoped<ICalculator, FakeCalculator>();
        });
    }
}
using Microsoft.Extensions.DependencyInjection;
using Testing.Client.Helpers;

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection);



static void ConfigureServices(IServiceCollection services)
{
    services
        .AddSingleton<INumberFormatter, NumberFormatter>();
}
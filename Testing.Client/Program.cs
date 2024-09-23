using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Testing.Client;
using Testing.Client.Helpers;
using Testing.Client.Services;

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection);
IServiceProvider provider = serviceCollection.BuildServiceProvider();
var client = provider.GetService<Client>();
client.Run();

static void ConfigureServices(IServiceCollection services)
{
    var builder = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", true, true);
    var config = builder.Build();

    services.AddSingleton<IConfiguration>(config);
    services.AddSingleton<INumberFormatter, NumberFormatter>();
    services.AddTransient<INumberVerificationApi, NumberVerificationApi>();
    services.AddTransient<INumberVerificationApiClient, NumberVerificationApiClient>();
    services.AddSingleton<Client>();
}
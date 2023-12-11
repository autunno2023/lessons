using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace PowerfulConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Configura IConfiguration
            var configuration = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                  .AddEnvironmentVariables()
                  .Build();

            // Configura il service provider
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(configuration)
                .AddSingleton<IMyService, MyService>()
                .BuildServiceProvider();

            // Ottieni il servizio e usalo
            var service = serviceProvider.GetService<IMyService>();
            service.DoSomething();
        }
    }
    public interface IMyService
    {
        void DoSomething();
    }

    public class MyService : IMyService
    {
        private readonly IConfiguration _configuration;

        public MyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void DoSomething()
        {
            var settingValue = _configuration["ConnectionStrings:DefaultConnection"];
            Console.WriteLine($"Valore di configurazione: {settingValue}");
        }
    }
}

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
                .AddTransient<IMyService, MyService>()
                .BuildServiceProvider();

            // Ottieni il servizio e usalo
            var service1 = serviceProvider.GetService<IMyService>();
            service1.DoSomething();
            var service2 = serviceProvider.GetService<IMyService>();
            service2.DoSomething();
        }
    }
    public interface IMyService
    {
        void DoSomething();
    }

    public class MyService : IMyService
    {
        private readonly IConfiguration _configuration;
        static int counter = 0;
        public MyService(IConfiguration configuration)
        {
            _configuration = configuration;
            counter++;
        }

        public void DoSomething()
        {
            Console.WriteLine($"Istanza N: {counter}");
            var settingValue = _configuration["ConnectionStrings:DefaultConnection"];
            Console.WriteLine($"Valore di configurazione: {settingValue}");
        }
    }
}

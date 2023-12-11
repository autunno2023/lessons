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
            var serviceProvider = new ServiceCollection();
            #region AddSingleton
            // registra l'oggetto IConfiguration nel container DI come singleton.
            // Questo significa che una singola istanza di IConfiguration verrà condivisa
            // in tutta l'applicazione. 
            serviceProvider.AddSingleton<IConfiguration>(configuration);

            #endregion
            serviceProvider.AddSingleton<IConfiguration>(configuration);

            #region AddTransient
            //La scelta di AddTransient implica una nuova istanza ad ogni richiesta.
            //Assicurati che questo comportamento sia adatto per il tuo EmailSender. 
            //Se, per esempio, EmailSender mantenesse stato o risorse (come una connessione di rete),
            //potresti voler considerare AddSingleton  
            serviceProvider.AddTransient<IMyService, MyService>();

            #endregion

            var provider = serviceProvider.BuildServiceProvider();

            // Ottieni il servizio e usalo
            var service1 = provider.GetService<IMyService>();
            service1.DoSomething();
            var service2 = provider.GetService<IMyService>();
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

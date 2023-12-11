using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace PowerfulConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 1 - Install Microsoft.Extensions.Options.ConfigurationExtensions


            // 2 - Configura IConfiguration
            var configuration = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                  .AddEnvironmentVariables()
                  .Build();

            // 3 - Configura il service provider
            var serviceCollection = new ServiceCollection();
            #region AddSingleton
            // registra l'oggetto IConfiguration nel container DI come singleton.
            // Questo significa che una singola istanza di IConfiguration verrà condivisa
            // in tutta l'applicazione.
            serviceCollection.AddSingleton<IConfiguration>(configuration);
            #endregion
            #region Deserializza il Config 
            serviceCollection.Configure<MyServiceSettings>(configuration.GetSection("MyServiceSettings"));
            #endregion
            #region AddTransient
            //La scelta di AddTransient implica una nuova istanza ad ogni richiesta.
            //Assicurati che questo comportamento sia adatto per il tuo EmailSender. 
            //Se, per esempio, EmailSender mantenesse stato o risorse(come una connessione di rete),
            //potresti voler considerare AddSingleton o AddScoped a seconda del tuo scenario
            //specifico.  
            serviceCollection.AddTransient<MyService>();

            #endregion
            #region BuildServiceProvider
            //Il metodo BuildServiceProvider è utilizzato nelle applicazioni.NET per costruire un 
            // ServiceProvider, che è il container effettivo per la Dependency Injection(DI).
            // Questo container è responsabile della risoluzione delle dipendenze e della gestione
            // del ciclo di vita dei servizi registrati.Ecco come funziona in un contesto di 
            // applicazione .NET:  
            var serviceProvider = serviceCollection.BuildServiceProvider();

            #endregion

            // 4 - Esempio di utilizzo del servizio (Simulazione)
            var MyService = serviceProvider.GetService<MyService>();
            MyService.DoSomething();
        }
    }

    public interface IMyService
    {
        void DoSomething();
    }
    public class MyService : IMyService
    {
        private readonly MyServiceSettings _configuration;

        public MyService(IOptions<MyServiceSettings> emailSettings)
        {
            _configuration = emailSettings.Value;
        }

        public void DoSomething()
        {

            Console.WriteLine($"Valore di configurazione: {_configuration.Server}");
            Console.WriteLine($"Valore di configurazione: {_configuration.Proxy}");
            Console.WriteLine($"Valore di configurazione: {_configuration.IpAddress}");
            Console.WriteLine($"Valore di configurazione: {_configuration.Backend}");
            Console.WriteLine($"Valore di configurazione: {_configuration.Fontend}");
        }
    }


}


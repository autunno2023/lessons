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


            Console.WriteLine(configuration.GetSection("ConnectionStrings:DefaultConnection:Connection"));
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
            serviceProvider.AddTransient<IReportGenerator, PdfReportGenerator>();

            #endregion

            var provider = serviceProvider.BuildServiceProvider();

            // Ottieni il servizio e usalo
            var service1 = provider.GetService<IReportGenerator>();
            service1.GenerateReport();
        }
    }

    public interface IReportGenerator
    {
        public void GenerateReport();
    }
    public class HtmlReportGenerator : IReportGenerator
    {
        private readonly IConfiguration _configuration;

        public HtmlReportGenerator(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public void GenerateReport()
        {
            // Genera report in formato HTML
            Console.WriteLine("<h1>Report</h1>"); ;
        }
    }
    public class PdfReportGenerator : IReportGenerator
    {
        private readonly IConfiguration _configuration;

        public PdfReportGenerator(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public void GenerateReport()
        {
            // Genera report in formato PDF
            Console.WriteLine("%PDF-1.4 Report");
        }
    }
    public class ConsumerService
    {
        private readonly IReportGenerator _generator;

        public ConsumerService(IReportGenerator generator)
        {
            _generator = generator;
        }

        public void DoWork()
        {

            _generator.GenerateReport();
        }
    }

}

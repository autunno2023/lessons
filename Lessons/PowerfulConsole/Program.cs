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

            var reportType = configuration.GetSection("ReportType").Value; // "Html" or "Pdf"

            // Configura il service provider
            var serviceProvider = new ServiceCollection();
            serviceProvider.AddSingleton<IConfiguration>(configuration); // Register IConfiguration
            serviceProvider.AddTransient<IReportGeneratorFactory, ReportGeneratorFactory>();
            serviceProvider.AddTransient<HtmlReportGenerator>();
            serviceProvider.AddTransient<PdfReportGenerator>();
            serviceProvider.AddTransient<ConsumerService>();

            var provider = serviceProvider.BuildServiceProvider();

            // Ottieni il direttamente il servizio e usalo
            var service1 = provider.GetService<IReportGenerator>();
            // service1.GenerateReport();

            // Ottieni il Consumer del  il servizio e usalo

            var consumerService = provider.GetService<ConsumerService>();
            consumerService.DoWork(reportType);
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
        //private readonly IReportGenerator _generator;

        //public ConsumerService(IReportGenerator generator)
        //{
        //    _generator = generator;
        //}

        //public void DoWork()
        //{

        //    _generator.GenerateReport();
        //} 
        private readonly IReportGeneratorFactory _factory;

        public ConsumerService(IReportGeneratorFactory factory)
        {
            _factory = factory;
        }

        public void DoWork(string reportType)
        {
            var generator = _factory.CreateGenerator(reportType);
            generator.GenerateReport();
        }
    }

}

using DataLayer.Dto.HR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Services;
using System;

namespace Presentation
{
    internal class Program
    {


        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            // Configura il service provider
            var serviceProvider = new ServiceCollection();

            //OptionsConfigurationServiceCollectionExtensions
            // .Configure<AppSettings>(serviceProvider, configuration.GetSection("AppSettings"));
            serviceProvider.AddSingleton<IConfiguration>(configuration);
            // serviceProvider.AddSingleton<AppSettings>();
            // serviceProvider.AddTransient<GenericDbContext<TResponse>>();
            serviceProvider.AddServiceLayerServices<EmployeesViewModelDToReq, HRServiceDToRes>(configuration);
            //serviceProvider.AddTransient<HRController>();
            //serviceProvider.AddTransient<IReportGenerator, HtmlReportGenerator>();
            //serviceProvider.AddTransient<ConsumerService>();

            //  var provider = serviceProvider.BuildServiceProvider();
            //var consumerService = provider.GetService<GenericDbContext>();
            //consumerService.DoWork();
            //  consumerService.DoWork();

            //EmployeesViewModelDTo? response = consumerService.GetEmployee(new EmployeesViewModelDToReq()
            //{
            //    Age = 10,
            //    Email = "bruno@gmail",
            //    //  CodiceFiscale = "FRRBRN82A14Z602H"
            //});


            Console.Read();
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

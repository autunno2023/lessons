using DataLayer.Dto.HR;
using Microsoft.Extensions.Configuration;
using Presentation.Controllers;
using System;

namespace Presentation
{
    internal class Program
    {
        static HRController controllers;

        static void Main(string[] args)
        {
            controllers = new HRController();


            EmployeesViewModelDTo? response = controllers.GetEmployee(
           new EmployeesViewModelDToReq()
           {
               Age = 10,
               Email = "bruno@gmail",
               //  CodiceFiscale = "FRRBRN82A14Z602H"
           });

            if (response?.Errors?.Count > 0)
            {
                foreach (var error in response.Errors)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(error);
                    Console.ResetColor();
                }
            }
            else
            {
                Utility.PrintGenericProps(response);

            }


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

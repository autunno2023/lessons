using Microsoft.Extensions.DependencyInjection;
using System;

namespace PowerfulConsole
{
    public class ReportGeneratorFactory : IReportGeneratorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ReportGeneratorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IReportGenerator CreateGenerator(string type)
        {
            return type switch
            {
                "Html" => _serviceProvider.GetService<HtmlReportGenerator>(),
                "Pdf" => _serviceProvider.GetService<PdfReportGenerator>(),
                _ => throw new ArgumentException("Invalid report type"),
            };
        }
    }

}

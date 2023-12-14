using DataLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Services.HR;
namespace ServiceLayer.Services
{
    public static class DataLayerServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceLayerServices<T, K>(this IServiceCollection services, IConfiguration configuration)
             where T : class, new()
             where K : class, new()
        {
            services.AddDataLayerServices<T, K>(configuration);
            services.AddTransient<HRService>();

            return services;
        }
    }
    public class DataLayerSettings
    {
        public string DefaultConnection { get; set; }
    }

}

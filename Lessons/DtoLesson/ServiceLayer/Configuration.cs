using DataLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace ServiceLayer.Services
{
    public static class DataLayerServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceLayerServices<T, K>(this IServiceCollection services, IConfiguration configuration)
             where T : class, new()
             where K : class, new()
        {
            services.AddDataLayerServices<T, K>(configuration);

            return services;
        }
    }
    public class DataLayerSettings
    {
        public string DefaultConnection { get; set; }
    }

}

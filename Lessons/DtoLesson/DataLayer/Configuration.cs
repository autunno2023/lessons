using DataLayer.Context;
using DataLayer.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace DataLayer
{
    public static class DataLayerServiceCollectionExtensions
    {
        public static IServiceCollection AddDataLayerServices<T, K>(this IServiceCollection services, IConfiguration configuration)
            where T : class, new()
            where K : class, new()
        {
            services.AddTransient<IDbContext, GenericDbContext<T>>();
            services.AddTransient<IRepository<T, K>, HRRepository<T, K>>();
            return services;
        }
    }


}

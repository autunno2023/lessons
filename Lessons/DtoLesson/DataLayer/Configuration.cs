using DataLayer.Context;
using DataLayer.Dto.HR;
using DataLayer.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace DataLayer
{
    public static class DataLayerServiceCollectionExtensions
    {
        public static IServiceCollection AddDataLayerServices<TRequest, TResponse>(this IServiceCollection services, IConfiguration configuration)

            where TRequest : class, new()
            where TResponse : class, new()
        {

            // services.AddTransient<IDbContext, GenericDbContext<HRServiceDToRes>>(); 
            services.AddTransient<GenericDbContext<TResponse>>();

            services.AddTransient<IRepository<EmployeesViewModelDToReq, HRServiceDToRes>, HRRepository<EmployeesViewModelDToReq, HRServiceDToRes>>();
            var provider = services.BuildServiceProvider();
            var consumerService = provider.GetService<GenericDbContext<TResponse>>();




            return services;
        }
    }


}

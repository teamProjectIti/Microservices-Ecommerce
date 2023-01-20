using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
  
namespace Core.extension.Catalog
{
    public static class AddDependInjuctionMangoDb
    {
        public static IServiceCollection AddinjectDbServices(this IServiceCollection services, IConfiguration confic)
        {
            return services;
        }
       

    }
}

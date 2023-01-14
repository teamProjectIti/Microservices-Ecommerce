using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositery.Implemint.Generic;
using static Repositery.Interface.Generic.IMongoRepository;

namespace Core.extension.Catalog
{
    public static class AddDependInjuctionMangoDb
    {
        public static IServiceCollection AddinjectDbServices(this IServiceCollection services, IConfiguration confic)
        {
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            return services;
        }
       

    }
}

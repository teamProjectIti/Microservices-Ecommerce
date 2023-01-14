using Data.Entities.Connection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Repositery.Implemint.Generic;

namespace Core.Extension
{
    public static class AddDependInjuctionMango
    {
        public static IServiceCollection AddinjectServices(this IServiceCollection services, IConfiguration confic)
        {
            
            services.AddScoped(typeof(MongoRepository<>), typeof(MongoRepository<>));
            return services;
        }

    }
}

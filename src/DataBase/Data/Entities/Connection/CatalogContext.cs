using Data.Entities.Catalog.Products;
using Data.Entities.Seed.Catalog;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
 
namespace Data.Entities.Connection
{
    public class CatalogContext: ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("ConnectionString"));
            var database = client.GetDatabase(configuration.GetConnectionString("DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetConnectionString("CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}

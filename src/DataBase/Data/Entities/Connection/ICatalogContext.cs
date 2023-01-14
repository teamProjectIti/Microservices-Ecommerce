using Data.Entities.Catalog.Products;
using MongoDB.Driver;

namespace Data.Entities.Connection
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}

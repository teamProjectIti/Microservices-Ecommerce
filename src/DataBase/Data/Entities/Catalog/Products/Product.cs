using Data.Entities.BaseData.Mango;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Entities.Catalog.Products
{
    [BsonCollection("Products")]
    public class Products: Document
    {
        [BsonElement("Name")]
        public string Name { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }
}

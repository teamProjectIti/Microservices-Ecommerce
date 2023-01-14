using MongoDB.Bson;

namespace Dto.Catalog.Product;
public class ProductDto
{
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public decimal Price { get; set; }
}

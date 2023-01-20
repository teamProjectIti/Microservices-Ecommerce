using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Data.Entities.BaseData.Mango
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; }
    }
}

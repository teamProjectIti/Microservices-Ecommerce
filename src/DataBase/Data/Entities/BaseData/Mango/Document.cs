using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Entities.BaseData.Mango
{
    public abstract class Document : IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}

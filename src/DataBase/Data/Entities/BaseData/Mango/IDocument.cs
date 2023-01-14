using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Data.Entities.BaseData.Mango
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        DateTime CreatedAt { get; }
        public bool IsDeleted { get; set; }

    }
}

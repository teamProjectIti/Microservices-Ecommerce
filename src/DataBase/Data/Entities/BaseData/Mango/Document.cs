using MongoDB.Bson;

namespace Data.Entities.BaseData.Mango
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}

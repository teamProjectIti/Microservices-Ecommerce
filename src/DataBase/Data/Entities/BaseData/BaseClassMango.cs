using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities.BaseData
{
    public class BaseClassMango
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public virtual string? IdString { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public string? LastModifiedBy { get; set; }
        public virtual DateTime? LastModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}

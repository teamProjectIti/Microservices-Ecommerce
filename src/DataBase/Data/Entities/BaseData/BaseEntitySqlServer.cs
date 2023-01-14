using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data.Entities.BaseData
{
    public abstract class BaseEntitySqlServer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long Id { get; set; }
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

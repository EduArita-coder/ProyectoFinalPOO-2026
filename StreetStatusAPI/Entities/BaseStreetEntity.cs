using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StreetStatusAPI.Entities
{
    public class BaseStreetEntity
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }

        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        [Column("last_modified_date")]
        public DateTime LastModifiedDate { get; set; }

        [Column("updated_by_id")]
        public string UpdatedById { get; set; }
        [Column("updated_date")]
        public DateTime UpdatedDate { get; set; }
    }
}
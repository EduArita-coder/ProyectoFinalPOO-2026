using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StreetStatusAPI.Entities
{
    [Table("streets")]
    public class Street : BaseStreetEntity
    {
        
        [Required]
        [Column("street_name")]
        public string StreetName { get; set; } = string.Empty;
        
        [Column("status")]
        public StreetStatus Status { get; set; }
        [Column("description")]

        public string Description { get; set; } = string.Empty;
        [Column("last_repair_date")]
        public DateTime LastRepairDate { get; set; }
        [Column("location_id")]
        [Required]
        public int LocationId { get; set; }
        [ForeignKey(nameof(LocationId))]
        public virtual Location Location { get; set; }

    }
}

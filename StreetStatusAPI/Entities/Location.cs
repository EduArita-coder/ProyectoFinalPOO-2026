using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreetStatusAPI.Entities
{
    [Table("locations")]
    public class Location : BaseStreetEntity
    {
        [Required]
        [StringLength(40)]
        [Column("City")]
        public string City{ get; set; }
        [Required]
        [Column("Street")]
        [StringLength(40)]
        public string Street { get; set; }
        [Required]
        [Column("ZipCode")]
        [StringLength(10)]
        public string ZipCode { get; set; }

        public virtual ICollection<StreetEntity> Streets { get; set; } = new List<StreetEntity>();

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreetStatusAPI.Entities
{
    [Table("locations")]
    public class Location : BaseStreetEntity
    {
        [StringLength(40)]
        [Column("Ciudad")]
        public string Name { get; set; }
        [Column("Calle")]
        [StringLength(40)]
        public string Calle { get; set; }
        [Column("Codigo_Postal")]
        [StringLength(10)]
        public string ZipCode { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}

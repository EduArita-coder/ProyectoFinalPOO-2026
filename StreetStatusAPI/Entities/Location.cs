using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreetStatusAPI.Entities
{
    [Table("locations")]
    public class Location
    {
        [Required]
        [StringLength(32)]
        public int Id { get; set; }
        [StringLength(40)]
        public string City { get; set; }
        [StringLength(40)]
        public string Province { get; set; }
        [StringLength(20)]
        public string Country { get; set; } 
        [StringLength(10)]
        public string ZipCode { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}

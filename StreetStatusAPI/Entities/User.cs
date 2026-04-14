using System.ComponentModel.DataAnnotations.Schema;

namespace StreetStatusAPI.Entities
{
    [Table("users")]
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } 
        public DateTime CreatedDate { get; set; }
    }
}

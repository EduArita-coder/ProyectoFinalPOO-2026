#nullable enable
namespace StreetStatusAPI.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string City { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }

        // Relación con Streets
        public ICollection<Street> Streets { get; set; } = new List<Street>();
    }
}

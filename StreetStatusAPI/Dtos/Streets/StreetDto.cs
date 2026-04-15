using StreetStatusAPI.Entities;

namespace StreetStatusAPI.Dtos.Streets
{
    public class StreetDto 
    {
        public string Id { get; set; }
        public string StreetName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime LastRepairDate { get; set; }
        public int LocationId { get; set; }
    }
}

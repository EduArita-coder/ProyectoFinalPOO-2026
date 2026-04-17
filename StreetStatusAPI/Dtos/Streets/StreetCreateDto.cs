using System.ComponentModel.DataAnnotations;

namespace StreetStatusAPI.Dtos.Streets
{
    public class StreetCreateDto
    {
        [Display(Name = "Nombre de la calle")]
        public string StreetName { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "la {0} es requerida.")]
        public string Description { get; set; }
        [Display(Name = "Ubicacion")]
        [Required(ErrorMessage = "la {0} es requerida")]
        public string LocationId { get; set; }
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "el {0} es requerido.")]
        public string Status { get; set; }
        [Display(Name = "Fecha de ultima reparacion")]
        [Required(ErrorMessage = "la {0} es requerida.")]
        public DateTime LastRepairDate { get; set; }
    }
}

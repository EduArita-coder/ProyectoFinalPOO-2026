using System.ComponentModel.DataAnnotations;

namespace StreetStatusAPI.Dtos.Locations
{
    public class LocationEditDto
    {
        [Required(ErrorMessage = "La ciudad es requerida.")]
        [StringLength(40, ErrorMessage = "La ciudad no puede tener mas de 40 caracteres.")]
        public string City { get; set; }

        [Required(ErrorMessage = "La calle es requerida.")]
        [StringLength(40, ErrorMessage = "La calle no puede tener mas de 40 caracteres.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "El codigo postal es requerido.")]
        [StringLength(10, ErrorMessage = "El codigo postal no puede tener mas de 10 caracteres.")]
        public string ZipCode { get; set; }
    }
}

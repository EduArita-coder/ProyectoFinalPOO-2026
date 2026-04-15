namespace StreetStatusAPI.Dtos.Streets
{
    public class StreetCreateDto
    {
        [Required(ErrorMessage = "El nombre de la calle es requerido.")]
        public string StreetName { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "la Descripcion es requerida.")]
        public string Description { get; set; }
        [Display(Name = "Ubicacion")]
        [Required(ErrorMessage = "la {0} es requerida")]
        public string LocationId { get; set; }
    }
}

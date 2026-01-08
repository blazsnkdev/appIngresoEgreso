using System.ComponentModel.DataAnnotations;

namespace appIngresoEgreso.Models.ViewModels
{
    public class AgregarCategoriaViewModel
    {
        [Display(Name ="Nombre"),Required(ErrorMessage ="El nombre es obligatorio"),StringLength(20,ErrorMessage ="Limite de 20 digitos")]
        public string Nombre { get; set; } = string.Empty;
        [Display(Name = "Nombre"), Required(ErrorMessage = "La descripción es obligatoria"), StringLength(200, ErrorMessage = "Limite de 200 digitos")]
        public string Descripcion { get; set; } = string.Empty;
    }
}

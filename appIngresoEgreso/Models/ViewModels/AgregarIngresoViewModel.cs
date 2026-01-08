using System.ComponentModel.DataAnnotations;

namespace appIngresoEgreso.Models.ViewModels
{
    public class AgregarIngresoViewModel
    {
        [Display(Name = "Ingrese el monto")]
        [Required(ErrorMessage ="Necesito ingresar un monto")]
        public decimal Monto { get; set; }
        public int IdMiembroFamilia { get; set; }
    }
}

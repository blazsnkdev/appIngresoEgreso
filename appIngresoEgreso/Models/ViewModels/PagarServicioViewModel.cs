using System.ComponentModel.DataAnnotations;

namespace appIngresoEgreso.Models.ViewModels
{
    public class PagarServicioViewModel
    {
        [Display(Name ="Miembro")]
        public int IdMiembro { get; set; }
        [Display(Name = "Servicio")]
        public int IdServicio { get; set; }
        [Display(Name = "Monto total")]
        [Range(0, double.MaxValue, ErrorMessage = "El monto debe ser un número positivo.")]
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        [Display(Name ="Número de mes")]
        public int Mes { get; set; }
        [Display(Name = "Año")]
        public int Anio { get; set; }
    }
}

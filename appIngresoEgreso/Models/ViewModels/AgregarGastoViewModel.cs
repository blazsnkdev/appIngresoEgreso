using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace appIngresoEgreso.Models.ViewModels
{
    public class AgregarGastoViewModel
    {
        //TODO: esto a un futuro debe ser el login autenticaction
        [Display(Name ="Nombre"),
            Required(ErrorMessage ="El campo es obligatorio")]
        public int IdMiembro { get; set; }
        [Display(Name = "Categoria"), 
            Required(ErrorMessage = "El campo es obligatorio")]
        public int IdCategoria { get; set; }
        [Display(Name = "Monto"),
            Required(ErrorMessage = "El campo es obligatorio"),
            Range(0,5000,ErrorMessage ="che flaco te re pasaste mal como vas a gastar tanta vaina")]
        public decimal Monto { get; set; }
        [Display(Name ="Descripción"), 
            Required(ErrorMessage ="Este campo es obligatorio"),
            StringLength(200,ErrorMessage ="Limite de 200 caracteres")]
        public string Descripcion { get; set; }
        [Display(Name = "Fecha del Gasto"),
            Required(ErrorMessage = "Se necesita la fecha")]
        public DateOnly FechaGasto { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [Display(Name ="Mediante"),
            Required(ErrorMessage ="Che se necesita el metodo del donde gasto mal")]
        public string MetodoPago { get; set; }
    }
}

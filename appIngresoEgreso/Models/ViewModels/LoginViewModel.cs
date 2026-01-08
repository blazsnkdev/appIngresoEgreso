using System.ComponentModel.DataAnnotations;

namespace appIngresoEgreso.Models.ViewModels
{
    public class LoginViewModel
    {
        [EmailAddress]
        [Display(Name ="Ingrese su Corrreo Electronico")]
        [StringLength(100,ErrorMessage ="Solo puede ingresar 100 caracteres")]
        [Required(ErrorMessage = "El correo electronico es obligatorio")]
        public string EmailInput { get; set; }
        [StringLength(100, ErrorMessage = "Solo puede ingresar 100 caracteres")]
        [Display(Name ="Ingrese su contraseña")]
        [Required(ErrorMessage = "El password es obligatorio")]
        public string PasswordInput { get; set; }
    }
}

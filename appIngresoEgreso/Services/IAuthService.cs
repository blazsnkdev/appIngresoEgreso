using appIngresoEgreso.Models.ViewModels;

namespace appIngresoEgreso.Services
{
    public interface IAuthService
    {
        //comentario XD
        bool Login(LoginViewModel viewModel);
        Task SignInAsync(HttpContext httpContext, LoginViewModel viewModel);
    }
}

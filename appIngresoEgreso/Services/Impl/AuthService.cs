using appIngresoEgreso.Dao;
using appIngresoEgreso.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace appIngresoEgreso.Services.Impl
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioDao _usuarioDAO;
        public AuthService(IUsuarioDao usuarioDao)
        {
            _usuarioDAO = usuarioDao;
        }
        public bool Login(LoginViewModel viewModel)
        {
            return _usuarioDAO.GetUsuarioByEmailAndPassword(viewModel.EmailInput, viewModel.PasswordInput);
        }

        public async Task SignInAsync(HttpContext httpContext, LoginViewModel viewModel)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, viewModel.EmailInput)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var props = new AuthenticationProperties
            {
                IsPersistent = true
            };
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), props);
        }
    }
}

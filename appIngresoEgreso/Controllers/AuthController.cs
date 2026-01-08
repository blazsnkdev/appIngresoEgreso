using appIngresoEgreso.Models.ViewModels;
using appIngresoEgreso.Services;
using Microsoft.AspNetCore.Mvc;

namespace appIngresoEgreso.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult Login() => View(new LoginViewModel());
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "El modelo no es valido");
                return View(viewModel);
            }
            var result = _authService.Login(viewModel);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "El usuario no existe");
                return View(viewModel);
            }
            return RedirectToAction("Index","Dashboard");
        }
    }
}

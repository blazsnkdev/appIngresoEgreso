using appIngresoEgreso.Models.ViewModels;
using appIngresoEgreso.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Login(LoginViewModel viewModel)
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
            await _authService.SignInAsync(HttpContext, viewModel);//NOTE: esto guarda el claim
            return RedirectToAction("Index", "Dashboard");
        }
    }
}

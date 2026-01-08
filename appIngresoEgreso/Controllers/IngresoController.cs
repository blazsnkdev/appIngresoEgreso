using appIngresoEgreso.Models.ViewModels;
using appIngresoEgreso.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace appIngresoEgreso.Controllers
{
    [Authorize]
    public class IngresoController : Controller
    {
        private readonly IIngresoService _ingresoServiec;
        private readonly IMiembroService _miembroService;

        public IngresoController(
            IIngresoService ingresoServiec,
            IMiembroService miembroService)
        {
            _ingresoServiec = ingresoServiec;
            _miembroService = miembroService;
        }

        public IActionResult Agregar()
        {
            CargarMiembroSelectList();
            return View(new AgregarIngresoViewModel());
        }
        [HttpPost]
        public IActionResult Agregar(AgregarIngresoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                CargarMiembroSelectList();
                return View(viewModel);
            }
            ViewBag.mensaje = _ingresoServiec.RegistrarIngreso(viewModel);
            CargarMiembroSelectList();
            return View();
        }
        private void CargarMiembroSelectList()
        {
            var list = _miembroService.SelectList();
            ViewBag.miembros = new SelectList(list, "IdMiembro", "Nombre");
        }
    }
}

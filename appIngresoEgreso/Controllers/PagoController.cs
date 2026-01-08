using appIngresoEgreso.Dao;
using appIngresoEgreso.Models.ViewModels;
using appIngresoEgreso.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace appIngresoEgreso.Controllers
{
    [Authorize]
    public class PagoController : Controller
    {
        private readonly IPagoServicioService _pagoServicioService;
        private readonly IServicioService _servicioService;
        private readonly IMiembroService _miembroService;
        public PagoController(IPagoServicioService pagoServicioService, IServicioService servicioService, IMiembroService miembroService)
        {
            _pagoServicioService = pagoServicioService;
            _servicioService = servicioService;
            _miembroService = miembroService;
        }
        public IActionResult Pagar()
        {
            CargarServicioSelectList(); 
            PagarServicioViewModel viewModel = new PagarServicioViewModel();
            viewModel.FechaPago = DateTime.Now;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Pagar(PagarServicioViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                CargarServicioSelectList();
                return View(viewModel);
            }
            var result = _pagoServicioService.RealizarPagoServicio(viewModel);
            if(result.Item1)
            {
                TempData["Mensaje"] = result.Item2;
                return RedirectToAction("Index", "Dashboard");
            }
            ViewBag.mensaje = result.Item2;
            CargarServicioSelectList();
            return View(viewModel); 
        }
        private void CargarServicioSelectList()
        {
            var list = _servicioService.GetSelectListServicios();
            var miembroFamiliaList = _miembroService.SelectList();
            ViewBag.Servicios = new SelectList(list, "ServicioId", "Nombre");
            ViewBag.Miembros = new SelectList(miembroFamiliaList, "IdMiembro", "Nombre");
        }
    }
}

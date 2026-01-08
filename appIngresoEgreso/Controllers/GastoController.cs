using appIngresoEgreso.Enums;
using appIngresoEgreso.Models.ViewModels;
using appIngresoEgreso.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace appIngresoEgreso.Controllers
{
    [Authorize]
    public class GastoController : Controller
    {
        private readonly IMiembroService _miembroService;
        private readonly IGastoService _gastoService;
        private readonly ICategoriaService _categoriaService;
        public GastoController(
            IMiembroService miembroService,
            IGastoService gastoService,
            ICategoriaService categoriaService)
        {
            _miembroService = miembroService;
            _gastoService = gastoService;
            _categoriaService = categoriaService;
        }
        public IActionResult Index() => View();
        public IActionResult Registrar()
        {
            MiembrosSelectList();
            MetodosPagoSelectList();
            CategoriasSelectLis();
            return View(new AgregarGastoViewModel());
        }
        [HttpPost]
        public IActionResult Registrar(AgregarGastoViewModel viewModel) 
        {
            if (!ModelState.IsValid)
            {
                MiembrosSelectList();
                MetodosPagoSelectList();
                CategoriasSelectLis();
                ModelState.AddModelError(string.Empty, "No se puedo registrar el gasto");
                return View(viewModel);
            }
            bool result = _gastoService.Registrar(viewModel);
            if (!result)
            {
                MiembrosSelectList();
                MetodosPagoSelectList();
                CategoriasSelectLis();
                ModelState.AddModelError(string.Empty, "No se puedo registrar el gasto");
                return View(viewModel);
            }
            return RedirectToAction("Index");
        }
        private void CategoriasSelectLis()
        {
            var list = _categoriaService.CategoriasSelect();
            ViewBag.Categorias = new SelectList(list,"IdCategoria","Nombre");
        }
        private void MiembrosSelectList()
        {
            var listMiembros = _miembroService.SelectList();
            ViewBag.Miembros = new SelectList(listMiembros, "IdMiembro", "Nombre");
        }
        private void MetodosPagoSelectList() {
            ViewBag.MetodosPago = new SelectList(
                Enum.GetValues(typeof(MetodoPago))
                .Cast<MetodoPago>().ToList());
        }
    }
}

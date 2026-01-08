using appIngresoEgreso.Models.ViewModels;
using appIngresoEgreso.Services;
using Microsoft.AspNetCore.Mvc;

namespace appIngresoEgreso.Controllers
{
    public class CategoriaController: Controller
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }
        public IActionResult Index()
        {
            return View(_categoriaService.Listar());
        }
        public IActionResult Add()
        {
            return View(new AgregarCategoriaViewModel());
        }
        [HttpPost]
        public IActionResult Add(AgregarCategoriaViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            bool resultado = _categoriaService.Agregar(viewModel);
            if (!resultado)
            {
                return View(viewModel);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int idCategoria)
        {
            var categoria = _categoriaService.CategoriaModificar(idCategoria);
            return View(categoria);
        }
        [HttpPost]
        public IActionResult Edit(ActualizarCategoriaViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            bool resultado = _categoriaService.Editar(viewModel);
            if (!resultado)
            {
                return View(viewModel);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(int idCategoria)
        {
            var resultado = _categoriaService.Delete(idCategoria);
            if (!resultado)
            {
                TempData["Mensaje"] = "Error";
                return RedirectToAction(nameof(Index));
            }
            TempData["Mensaje"] = "Eliminado";
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Desactivar(int idCategoria)
        {
            var resultado = _categoriaService.Desactivar(idCategoria);
            if (!resultado)
            {
                TempData["Mensaje"] = "Error";
                return RedirectToAction("Index");
            }
            TempData["Mensaje"] = "Desactivado";
            return RedirectToAction(nameof(Index));
        }
    }
}

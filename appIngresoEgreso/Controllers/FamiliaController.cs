using appIngresoEgreso.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace appIngresoEgreso.Controllers
{
    [Authorize]
    public class FamiliaController : Controller
    {
        private readonly IMiembroService _familiaService;
        public FamiliaController(IMiembroService familiaService)
        {
            _familiaService = familiaService;
        }
        public IActionResult Index()
        {
            return View(_familiaService.GetFamiliaInfoList());
        }
    }
}

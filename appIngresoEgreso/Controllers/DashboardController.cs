using appIngresoEgreso.Dao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace appIngresoEgreso.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IDahsboardDao _dahsboardDao;
        public DashboardController(IDahsboardDao dahsboardDao)
        {
            _dahsboardDao = dahsboardDao;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetGastosYServiciosPorMes()
        {
            var gastosMes = _dahsboardDao.GetMontoGastosPorMesActual() ?? 0;
            var servisioMes = _dahsboardDao.GetMontoServiciosPorMesActual() ?? 0;
            return Json(new
            {
                gasto = gastosMes,
                servicio = servisioMes,
            });
        }
    }
}

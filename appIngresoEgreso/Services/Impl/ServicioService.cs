using appIngresoEgreso.Dao;
using appIngresoEgreso.Models.ViewModels;

namespace appIngresoEgreso.Services.Impl
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioDao _servicioDao;

        public ServicioService(IServicioDao servicioDao)
        {
            _servicioDao = servicioDao;
        }
        public List<SelectListServiciosViewModel> GetSelectListServicios()
        {
            return _servicioDao.GetAllServicios()
                .Select(s => new SelectListServiciosViewModel
                {
                    ServicioId = s.ServicioId,
                    Nombre = s.Nombre
                })
                .ToList();
        }
    }
}

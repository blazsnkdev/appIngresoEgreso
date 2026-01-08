using appIngresoEgreso.Models.ViewModels;

namespace appIngresoEgreso.Services
{
    public interface IServicioService
    {
        List<SelectListServiciosViewModel> GetSelectListServicios();
    }
}

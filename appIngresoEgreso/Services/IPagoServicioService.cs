using appIngresoEgreso.Models.ViewModels;

namespace appIngresoEgreso.Services
{
    public interface IPagoServicioService
    {
        bool RealizarPagoServicio(PagarServicioViewModel viewModel);
    }
}

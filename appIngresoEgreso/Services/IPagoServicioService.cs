using appIngresoEgreso.Models.ViewModels;

namespace appIngresoEgreso.Services
{
    public interface IPagoServicioService
    {
        (bool,string) RealizarPagoServicio(PagarServicioViewModel viewModel);
    }
}

using appIngresoEgreso.Models.ViewModels;

namespace appIngresoEgreso.Services
{
    public interface IGastoService
    {
        bool Registrar(AgregarGastoViewModel viewModel);
    }
}

using appIngresoEgreso.Models.ViewModels;

namespace appIngresoEgreso.Services
{
    public interface IIngresoService
    {
        string RegistrarIngreso(AgregarIngresoViewModel viewModel);
    }
}

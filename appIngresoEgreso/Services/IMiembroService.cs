using appIngresoEgreso.Models.ViewModels;

namespace appIngresoEgreso.Services
{
    public interface IMiembroService
    {
        List<MiembroSelectListViewModel> SelectList();
    }
}

using appIngresoEgreso.Models;

namespace appIngresoEgreso.Dao
{
    public interface IPagoDao
    {
        bool PagarServicio(PagoServicio pagoServicio);
        List<PagoServicio> GetAll();
    }
}

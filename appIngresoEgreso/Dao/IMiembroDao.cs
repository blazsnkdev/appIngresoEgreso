using appIngresoEgreso.Models;

namespace appIngresoEgreso.Dao
{
    public interface IMiembroDao
    {
        IEnumerable<Miembro> GetAll();
        IEnumerable<Miembro> GetAllIds();
    }
}

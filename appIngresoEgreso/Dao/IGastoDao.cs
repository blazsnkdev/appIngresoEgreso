using appIngresoEgreso.Models;

namespace appIngresoEgreso.Dao
{
    public interface IGastoDao
    {
        bool Add(Gasto gasto);
        bool Edit(Gasto gasto);
        bool Delete(int idGasto);
        IEnumerable<Gasto> GetAllByRangeFecha(DateOnly fechaInicio,DateOnly fechaFin);
        IEnumerable<Gasto> GetAllByCategoria(int idCategoria);
        IEnumerable<Gasto> GetAllByMiembro(int idMiembro);
    }
}

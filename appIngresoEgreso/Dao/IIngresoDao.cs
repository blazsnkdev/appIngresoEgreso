using appIngresoEgreso.Models;

namespace appIngresoEgreso.Dao
{
    public interface IIngresoDao
    {
        bool exec_sp_nuevo_ingreso(Ingreso ingreso);
    }
}

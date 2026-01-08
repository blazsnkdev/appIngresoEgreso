using appIngresoEgreso.Models;

namespace appIngresoEgreso.Dao
{
    public interface IUsuarioDao
    {
        bool GetUsuarioByEmailAndPassword(string email,string password);
    }
}

using appIngresoEgreso.Models;

namespace appIngresoEgreso.Dao
{
    public interface ICategoriaDao
    {
        IEnumerable<Categoria> GetAll();
        IEnumerable<Categoria> GetActivos();
        bool Add(Categoria objCategoria);
        bool Update(Categoria objCategoria);
        bool Delete(int idCategoria);
        bool DarBaja(int idCategoria);
        Categoria? GetById(int idCategoria);
    }
}

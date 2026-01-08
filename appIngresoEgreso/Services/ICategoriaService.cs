using appIngresoEgreso.Models;
using appIngresoEgreso.Models.ViewModels;

namespace appIngresoEgreso.Services
{
    public interface ICategoriaService
    {
        List<CategoriaSelectListViewModel> CategoriasSelect();
        List<Categoria> Listar();
        bool Agregar(AgregarCategoriaViewModel viewModel);
        bool Editar(ActualizarCategoriaViewModel viewModel);
        bool Delete(int idCategoria);
        bool Desactivar(int idCategoria);
        ActualizarCategoriaViewModel CategoriaModificar(int idCategoria);
    }
}

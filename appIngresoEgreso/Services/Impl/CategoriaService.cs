using appIngresoEgreso.Dao;
using appIngresoEgreso.Models;
using appIngresoEgreso.Models.ViewModels;

namespace appIngresoEgreso.Services.Impl
{
    public class CategoriaService : ICategoriaService
    {
        private ICategoriaDao _categoriaDao;
        public CategoriaService(ICategoriaDao categoriaDao)
        {
            _categoriaDao = categoriaDao;
        }
        public bool Agregar(AgregarCategoriaViewModel viewModel)
        {
            var categoria = new Categoria()
            {
                Nombre = viewModel.Nombre,
                Descripcion = viewModel.Descripcion
            };
            return _categoriaDao.Add(categoria);
        }

        public bool Delete(int idCategoria)
        {
            return _categoriaDao.Delete(idCategoria);
        }

        public bool Desactivar(int idCategoria)
        {
            return _categoriaDao.DarBaja(idCategoria);
        }

        public bool Editar(ActualizarCategoriaViewModel viewModel)
        {
            var categoriaCambios = new Categoria()
            {
                IdCategoria = viewModel.IdCategoria,
                Nombre = viewModel.Nombre,
                Descripcion = viewModel.Descripcion
            };
            return _categoriaDao.Update(categoriaCambios);
        }

        public List<CategoriaSelectListViewModel> CategoriasSelect()
        {
            var lista = _categoriaDao.GetActivos();
            return lista.Select(c => new CategoriaSelectListViewModel()
            {
                IdCategoria = c.IdCategoria,
                Nombre = c.Nombre
            }).ToList();
        }

        public List<Categoria> Listar()
        {
            IEnumerable<Categoria> lista = [];
            lista = _categoriaDao.GetAll();
            return lista.Select(c => new Categoria()
            {
                IdCategoria = c.IdCategoria,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                Estado = c.Estado
            }).ToList();
        }

        public ActualizarCategoriaViewModel CategoriaModificar(int idCategoria)
        {
            var categoriaAct = new ActualizarCategoriaViewModel();
            var categoria = _categoriaDao.GetById(idCategoria);
            if (categoria != null)
            {
                categoriaAct.IdCategoria = categoria.IdCategoria;
                categoriaAct.Nombre = categoria.Nombre;
                categoriaAct.Descripcion = categoria.Descripcion;
            }
            return categoriaAct;
        }
    }
}

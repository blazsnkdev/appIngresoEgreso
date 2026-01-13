using appIngresoEgreso.Dao;
using appIngresoEgreso.Models.ViewModels;

namespace appIngresoEgreso.Services.Impl
{
    public class MiembroService : IMiembroService
    {
        private readonly IMiembroDao _miembroDao;

        public MiembroService(IMiembroDao miembroDao)
        {
            _miembroDao = miembroDao;
        }

        public List<MiembroFamiliaInfoViewModel> GetFamiliaInfoList()
        {
            var list = _miembroDao.GetInfoMiembrosAll();
            return list.Select(x => new MiembroFamiliaInfoViewModel()
            {
                Id = x.IdMiembro,
                Nombre = x.Nombre,
                Rol = x.Rol.ToString(),
                Monto = x.MontoTotal
            }).ToList();
        }

        public List<MiembroSelectListViewModel> SelectList()
        {
            var miembros = _miembroDao.GetAll();
            return miembros.Select(a => new MiembroSelectListViewModel()
            {
                IdMiembro = a.IdMiembro,
                Nombre = a.Nombre
            }).ToList();
        }
    }
}

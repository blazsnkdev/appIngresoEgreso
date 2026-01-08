using appIngresoEgreso.Dao;
using appIngresoEgreso.Models;
using appIngresoEgreso.Models.ViewModels;

namespace appIngresoEgreso.Services.Impl
{
    public class IngresoService : IIngresoService
    {
        private readonly IIngresoDao _ingresoDao;

        public IngresoService(IIngresoDao ingresoDao)
        {
            _ingresoDao = ingresoDao;
        }

        public string RegistrarIngreso(AgregarIngresoViewModel viewModel)
        {
            if(viewModel.Monto <= 0)
            {
                return "Debe Ingresar un monto positivo";
            }
            var ingreso = new Ingreso();
            ingreso.Monto = viewModel.Monto;
            ingreso.IdMiembroFamilia = viewModel.IdMiembroFamilia;
            _ingresoDao.exec_sp_nuevo_ingreso(ingreso);
            return "Registrado!";
        }
    }
}

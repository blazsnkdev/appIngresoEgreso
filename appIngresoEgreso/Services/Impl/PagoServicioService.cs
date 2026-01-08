using appIngresoEgreso.Dao;
using appIngresoEgreso.Models;
using appIngresoEgreso.Models.ViewModels;

namespace appIngresoEgreso.Services.Impl
{
    public class PagoServicioService : IPagoServicioService
    {
        private readonly IPagoDao _pagoDao;
        public PagoServicioService(IPagoDao pagoDao)
        {
            _pagoDao = pagoDao;
        }
        public bool RealizarPagoServicio(PagarServicioViewModel viewModel)
        {
            if(viewModel.Monto <= 0)
            {
                return false;
            }
            var pago = new PagoServicio()
            {
                IdMiembro = viewModel.IdMiembro,
                IdServicio = viewModel.IdServicio,
                Monto = viewModel.Monto,
                FechaPago = viewModel.FechaPago,
                PeriodoMes = viewModel.Mes,
                PeriodoAnio = viewModel.Anio,
                EstadoPago = Enums.EstadoPagoServicio.PAGADO
            };
            return _pagoDao.PagarServicio(pago);
        }
    }
}

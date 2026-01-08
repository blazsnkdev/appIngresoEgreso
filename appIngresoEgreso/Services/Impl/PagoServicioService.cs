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
        public (bool,string) RealizarPagoServicio(PagarServicioViewModel viewModel)
        {
            var pagosExistentes = _pagoDao.GetAll();
            var existe = pagosExistentes.Any(x => x.PeriodoAnio == viewModel.Anio && x.PeriodoMes == viewModel.Mes && x.IdServicio == viewModel.IdServicio);//NOTE: para no repetir pagos en el mismo mes y anio
            if (existe)
            {
                return (false, $"Ya hay un pago registrado para este servicio en el mes {viewModel.Mes} y año {viewModel.Anio}");
            }
            if (viewModel.Monto <= 0)
            {
                return (false, "Ya existe un pago para el mismo mes y año.");
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
            return _pagoDao.PagarServicio(pago) ? (true, "Pago del servicio realizado con éxito.") : (false, "Error al realizar el pago.");
        }
    }
}

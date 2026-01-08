using appIngresoEgreso.Dao;
using appIngresoEgreso.Enums;
using appIngresoEgreso.Models;
using appIngresoEgreso.Models.ViewModels;

namespace appIngresoEgreso.Services.Impl
{
    public class GastoService : IGastoService
    {
        private readonly IGastoDao _gastoDao;

        public GastoService(IGastoDao gastoDao)
        {
            _gastoDao = gastoDao;
        }

        public bool Registrar(AgregarGastoViewModel viewModel)
        {
            MetodoPago metodoPagoConvertido = MetodoPago.Defecto;
            if(Enum.TryParse<MetodoPago>(viewModel.MetodoPago, true,out var temp))
            {
                metodoPagoConvertido = temp;
            }
            var gasto = new Gasto()
            {
                IdCategoria = viewModel.IdCategoria,
                IdMiembro = viewModel.IdMiembro,
                Monto = viewModel.Monto,
                Descripcion = viewModel.Descripcion,
                FechaGasto = viewModel.FechaGasto,
                MetodoPago = metodoPagoConvertido
            };
            var result = _gastoDao.Add(gasto);

            return result;
        }
    }
}

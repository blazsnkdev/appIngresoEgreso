namespace appIngresoEgreso.Dao
{
    public interface IDahsboardDao
    {
        decimal? GetMontoGastosPorMesActual();
        decimal? GetMontoServiciosPorMesActual();
        decimal? GetMontoGastosPorCategoriaYMes(int idCategoria, int numMes);
        decimal? GetMontoServiciosPorTipoYMes(int idServicio, int numMes);
    }
}

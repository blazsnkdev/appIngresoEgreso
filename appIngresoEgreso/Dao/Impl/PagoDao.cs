using appIngresoEgreso.Models;
using System.Data.SqlClient;

namespace appIngresoEgreso.Dao.Impl
{
    public class PagoDao : IPagoDao
    {
        private readonly string _cadenaConexion;

        public PagoDao(IConfiguration cfg)
        {
            _cadenaConexion = cfg.GetConnectionString("cn1") ?? throw new ArgumentNullException("Connection string 'cn1' not found.");
        }
        public bool PagarServicio(PagoServicio pagoServicio)
        {
            using var conexion = new SqlConnection(_cadenaConexion);
            using var comando = new SqlCommand("sp_pago_servicio", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdServicio", pagoServicio.IdServicio);
            comando.Parameters.AddWithValue("@IdMiembro", pagoServicio.IdMiembro);
            comando.Parameters.AddWithValue("@Monto", pagoServicio.Monto);
            comando.Parameters.AddWithValue("@FechaPago", pagoServicio.FechaPago);
            comando.Parameters.AddWithValue("@PeriodoMes", pagoServicio.PeriodoMes);
            comando.Parameters.AddWithValue("@PeriodoAnio", pagoServicio.PeriodoAnio);
            comando.Parameters.AddWithValue("@EstadoPago", pagoServicio.EstadoPago.ToString());
            conexion.Open();
            int fa = comando.ExecuteNonQuery();
            return fa > 0;
        }
    }
}

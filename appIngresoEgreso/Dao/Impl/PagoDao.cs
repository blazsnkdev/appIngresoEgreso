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

        public List<PagoServicio> GetAll()
        {
            var list = new List<PagoServicio>();
            using var conexion = new SqlConnection(_cadenaConexion);
            using var comando = new SqlCommand("sp_get_all_pagos_servicios", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                list.Add(new PagoServicio()
                {
                    IdPagoServicio = lector.GetInt32(lector.GetOrdinal("IdPagoServicio")),
                    IdServicio = lector.GetInt32(lector.GetOrdinal("IdServicio")),
                    IdMiembro = lector.GetInt32(lector.GetOrdinal("IdMiembro")),
                    Monto = lector.GetDecimal(lector.GetOrdinal("Monto")),
                    FechaPago = lector.GetDateTime(lector.GetOrdinal("FechaPago")),
                    PeriodoMes = lector.GetInt32(lector.GetOrdinal("PeriodoMes")),
                    PeriodoAnio = lector.GetInt32(lector.GetOrdinal("PeriodoAnio")),
                });
            }
            return list;
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

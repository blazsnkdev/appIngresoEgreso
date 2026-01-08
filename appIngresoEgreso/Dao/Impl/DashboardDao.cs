using Microsoft.Extensions.Logging.Abstractions;
using System.Data;
using System.Data.SqlClient;

namespace appIngresoEgreso.Dao.Impl
{
    public class DashboardDao : IDahsboardDao
    {
        private readonly string _cadenaConexion;
        public DashboardDao(IConfiguration cfg)
        {
            _cadenaConexion = cfg.GetConnectionString("cn1") ?? throw new ArgumentNullException("Connection string 'cn1' not found.");
        }

        public decimal? GetMontoGastosPorCategoriaYMes(int idCategoria, int numMes)
        {
            decimal? monto = null;
            using SqlConnection cn = new SqlConnection(_cadenaConexion);
            cn.Open();
            using SqlCommand cmd = new SqlCommand("sp_total_gasto_categoria_mes", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@IdCategoria", SqlDbType.Int)).Value = idCategoria;
            cmd.Parameters.Add(new SqlParameter("@Mes", SqlDbType.Int)).Value = numMes;
            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                int index = dr.GetOrdinal("total");
                if (!dr.IsDBNull(index))
                {
                    monto = dr.GetDecimal(index);
                }
            }
            return monto;

        }

        public decimal? GetMontoGastosPorMesActual()
        {
            decimal? monto = null;
            using (SqlConnection cn = new SqlConnection(_cadenaConexion))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_total_gastos_mes", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            try
                            {
                                int index = dr.GetOrdinal("totalmes");
                                if (!dr.IsDBNull(index))
                                {
                                    monto = dr.GetDecimal(index);
                                }
                            }
                            catch
                            {
                                monto = null;
                            }
                        }
                    }
                }
            }
            return monto;
        }

        public decimal? GetMontoServiciosPorMesActual()
        {
            decimal? monto = null;
            using (SqlConnection cn = new SqlConnection(_cadenaConexion))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_total_servicios_mes", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            int index = dr.GetOrdinal("totalServicioMes");
                            if (!dr.IsDBNull(index))
                            {
                                monto = dr.GetDecimal(index);
                            }
                        }
                    }
                }
            }
            return monto;
        }

        public decimal? GetMontoServiciosPorTipoYMes(int idServicio, int numMes)
        {
            decimal? monto = null;
            using (SqlConnection cn = new SqlConnection(_cadenaConexion))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_total_servicio_categoria_mes", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdServicio", SqlDbType.Int)).Value = idServicio;
                    cmd.Parameters.Add(new SqlParameter("@Mes", SqlDbType.Int)).Value = numMes;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            int index = dr.GetOrdinal("total");
                            if (!dr.IsDBNull(index))
                            {
                                monto = dr.GetDecimal(index);
                            }
                        }
                    }
                }
            }
            return monto;
        }
    }
}

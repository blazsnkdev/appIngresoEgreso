using appIngresoEgreso.Models;
using System.Data.SqlClient;

namespace appIngresoEgreso.Dao.Impl
{
    public class GastoDao : IGastoDao
    {
        private string _cadenaConexion;
        public GastoDao(IConfiguration cfg)
        {
            _cadenaConexion = cfg.GetConnectionString("cn1")!;
        }
        public bool Add(Gasto gasto)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_cadenaConexion))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_registrar_gasto", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@IdMiembro", System.Data.SqlDbType.Int)).Value = gasto.IdMiembro;
                        cmd.Parameters.Add(new SqlParameter("@IdCategoria", System.Data.SqlDbType.Int)).Value = gasto.IdCategoria;
                        cmd.Parameters.Add(new SqlParameter("@Monto", System.Data.SqlDbType.Decimal)).Value = gasto.Monto;
                        cmd.Parameters.Add(new SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar,200)).Value = gasto.Descripcion;
                        cmd.Parameters.Add(new SqlParameter("@FechaGasto", System.Data.SqlDbType.Date)).Value = gasto.FechaGasto.ToDateTime(TimeOnly.MinValue);
                        cmd.Parameters.Add(new SqlParameter("@MetodoPago", System.Data.SqlDbType.VarChar, 50)).Value = gasto.MetodoPago;
                        int fa = cmd.ExecuteNonQuery();
                        return fa > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(int idGasto)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Gasto gasto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Gasto> GetAllByCategoria(int idCategoria)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Gasto> GetAllByMiembro(int idMiembro)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Gasto> GetAllByRangeFecha(DateOnly fechaInicio, DateOnly fechaFin)
        {
            throw new NotImplementedException();
        }
    }
}

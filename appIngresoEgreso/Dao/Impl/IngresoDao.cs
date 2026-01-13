using appIngresoEgreso.Models;
using System.Data.SqlClient;

namespace appIngresoEgreso.Dao.Impl
{
    public class IngresoDao : IIngresoDao
    {
        private string _connectionString;

        public IngresoDao(IConfiguration cfg)
        {
            _connectionString = cfg.GetConnectionString("cn1");
        }
        public bool exec_sp_nuevo_ingreso(Ingreso ingreso)
        {
            try
            {
                using SqlConnection cn = new SqlConnection(_connectionString);
                using SqlCommand cmd = new SqlCommand("sp_nuevo_ingreso", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var monto = cmd.Parameters.Add("@monto", System.Data.SqlDbType.Decimal);
                monto.Precision = 10;
                monto.Scale = 2;
                monto.Value = ingreso.Monto;
                cmd.Parameters.Add("@idMiembro", System.Data.SqlDbType.Int).Value = ingreso.IdMiembroFamilia;
                cn.Open();
                var s = cmd.ExecuteScalar();
                return s is null;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error sql: "+ex.Message);
                return false;
            }
        }
    }
}

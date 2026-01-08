using appIngresoEgreso.Models;
using System.Data;
using System.Data.SqlClient;

namespace appIngresoEgreso.Dao.Impl
{
    public class UsuarioDao : IUsuarioDao
    {
        private string _connectionString;
        public UsuarioDao(IConfiguration cfg)
        {
            _connectionString = cfg.GetConnectionString("cn1")!;
        }
        public bool GetUsuarioByEmailAndPassword(string email, string password)
        {
            using SqlConnection cn = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand("SP_LOGIN", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@EMAIL", SqlDbType.VarChar,100)).Value = email;
            cmd.Parameters.Add(new SqlParameter("@CONTRASEÑA", SqlDbType.VarChar, 100)).Value = password;
            cn.Open();
            object result = cmd.ExecuteScalar();
            cn.Close();
            return result != null;
        }
    }
}

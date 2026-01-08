using appIngresoEgreso.Models;
using System.Data.SqlClient;

namespace appIngresoEgreso.Dao.Impl
{
    public class ServicioDao : IServicioDao
    {
        private readonly string _cadenaConexion;

        public ServicioDao(IConfiguration cfg)
        {
            _cadenaConexion = cfg.GetConnectionString("cn1") ?? throw new ArgumentNullException("Connection string 'cn1' not found.");
        }

        public List<Servicio> GetAllServicios()
        {
            var list = new List<Servicio>();
            using var conexion = new SqlConnection(_cadenaConexion);
            using var comando = new SqlCommand("sp_get_servicios", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            conexion.Open();
            using var lector = comando.ExecuteReader();
            while (lector.Read()) {
                list.Add(new Servicio
                {
                    ServicioId = lector.GetInt32(lector.GetOrdinal("IdServicio")),
                    Nombre = lector.GetString(lector.GetOrdinal("Nombre")),
                    Empresa = lector.GetString(lector.GetOrdinal("Empresa")),
                    FechaRegistro = DateOnly.FromDateTime(lector.GetDateTime(lector.GetOrdinal("FechaRegistro"))),
                    Estado = lector.GetString(lector.GetOrdinal("Estado"))
                });
            }
            return list;
        }
    }
}

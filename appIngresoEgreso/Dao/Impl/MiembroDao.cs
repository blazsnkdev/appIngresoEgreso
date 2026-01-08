using appIngresoEgreso.Enums;
using appIngresoEgreso.Models;
using System.Data.SqlClient;

namespace appIngresoEgreso.Dao.Impl
{
    public class MiembroDao : IMiembroDao
    {
        private readonly string _cadenaConexion;
        public MiembroDao(IConfiguration cfg)
        {
            _cadenaConexion = cfg.GetConnectionString("cn1")!;
        }
        public IEnumerable<Miembro> GetAll()
        {
            var list = new List<Miembro>();
            using (SqlConnection cn = new SqlConnection(_cadenaConexion))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_listar_miembros",cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string rolString = dr.GetString(dr.GetOrdinal("Rol"));
                            Rol rolConvertido = Rol.Hijo;
                            if (Enum.TryParse<Rol>(rolString, true, out var tempRol))
                            {
                                rolConvertido = tempRol;
                            }
                            list.Add(new Miembro()
                            {
                                IdMiembro = dr.GetInt32(dr.GetOrdinal("IdMiembro")),
                                Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                                Rol = rolConvertido
                            });
                        }
                    }
                }
            }
             return list;
        }

        public IEnumerable<Miembro> GetAllIds()
        {
            List<Miembro> miembros = new List<Miembro>();
            using SqlConnection cn = new SqlConnection(_cadenaConexion);
            using SqlCommand cmd = new SqlCommand("sp_get_idMiembros", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                miembros.Add(new Miembro()
                {
                    IdMiembro = dr.GetInt32(dr.GetOrdinal("idMiembro")),
                    Nombre = dr.GetString(dr.GetOrdinal("Nombre"))
                });
            }
            return miembros;
        }
    }
}

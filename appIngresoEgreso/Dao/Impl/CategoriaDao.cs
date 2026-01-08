using appIngresoEgreso.Models;
using System.Data.SqlClient;

namespace appIngresoEgreso.Dao.Impl
{
    public class CategoriaDao : ICategoriaDao
    {
        private readonly string _cadenaConexion;
        public CategoriaDao(IConfiguration cfg)
        {
            _cadenaConexion = cfg.GetConnectionString("cn1")!;
        }
        public bool Add(Categoria objCategoria)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_cadenaConexion))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_agregar_categoria", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar, 20)).Value = objCategoria.Nombre;
                        cmd.Parameters.Add(new SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 200)).Value = objCategoria.Descripcion;
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DarBaja(int idCategoria)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_cadenaConexion))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_dar_baja_categoria", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@IdCategoria", System.Data.SqlDbType.Int)).Value = idCategoria;
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(int idCategoria)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_cadenaConexion))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_eliminar_categoria", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@IdCategoria", System.Data.SqlDbType.Int)).Value = idCategoria;
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public IEnumerable<Categoria> GetActivos()
        {
            List<Categoria> lista = new List<Categoria>();
            using (SqlConnection cn = new SqlConnection(_cadenaConexion))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_listar_categorias_activas", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Categoria()
                            {
                                IdCategoria = dr.GetInt32(dr.GetOrdinal("IdCategoria")),
                                Nombre = dr.GetString(dr.GetOrdinal("Nombre"))
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public IEnumerable<Categoria> GetAll()
        {
            List<Categoria> lista = new List<Categoria>();
            using (SqlConnection cn = new SqlConnection(_cadenaConexion))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_listar_categorias", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Categoria()
                            {
                                IdCategoria = dr.GetInt32(dr.GetOrdinal("IdCategoria")),
                                Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                                Descripcion = dr.IsDBNull(dr.GetOrdinal("Descripcion")) ? string.Empty : dr.GetString(dr.GetOrdinal("Descripcion")),
                                Estado = dr.GetString(dr.GetOrdinal("Estado"))
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public Categoria? GetById(int idCategoria)
        {
            Categoria? categoria = new Categoria();
            using (SqlConnection cn = new SqlConnection(_cadenaConexion))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_obtener_categoria_id", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdCategoria", System.Data.SqlDbType.Int)).Value = idCategoria;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            categoria.IdCategoria = idCategoria;
                            categoria.Nombre = dr.GetString(dr.GetOrdinal("Nombre"));
                            categoria.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"));
                            categoria.Estado = dr.GetString(dr.GetOrdinal("Estado"));
                        }
                    }
                }
            }
            return categoria;
        }

        public bool Update(Categoria objCategoria)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(_cadenaConexion))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_actualizar_categoria", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@IdCategoria", System.Data.SqlDbType.Int)).Value = objCategoria.IdCategoria;
                        cmd.Parameters.Add(new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar, 20)).Value = objCategoria.Nombre;
                        cmd.Parameters.Add(new SqlParameter("@Descripcion", System.Data.SqlDbType.VarChar, 200)).Value = objCategoria.Descripcion;
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}

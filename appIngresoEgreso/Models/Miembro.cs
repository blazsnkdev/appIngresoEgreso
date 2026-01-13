using appIngresoEgreso.Enums;
using System.Security.Principal;

namespace appIngresoEgreso.Models
{
    public class Miembro
    {
        public int IdMiembro { get; set; }
        public string Nombre { get; set; }
        public Rol Rol { get; set; }
        public decimal? MontoTotal { get; set; }
    }
}

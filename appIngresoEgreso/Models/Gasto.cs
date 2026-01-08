using appIngresoEgreso.Enums;

namespace appIngresoEgreso.Models
{
    public class Gasto
    {
        public int IdGasto { get; set; }
        public int IdMiembro { get; set; }
        public int IdCategoria { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public DateOnly FechaGasto { get; set; }
        public MetodoPago MetodoPago { get; set; }
    }
}

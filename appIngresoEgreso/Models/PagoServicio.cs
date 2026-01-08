using appIngresoEgreso.Enums;

namespace appIngresoEgreso.Models
{
    public class PagoServicio
    {
        public int IdPagoServicio { get; set; }
        public int IdServicio { get; set; }
        public int IdMiembro { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public int PeriodoMes { get; set; }
        public int PeriodoAnio { get; set; }
        public EstadoPagoServicio EstadoPago { get; set; }
    }
}

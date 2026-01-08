namespace appIngresoEgreso.Models
{
    public class Ingreso
    {
        public int IdIngreso { get; set; }
        public decimal Monto { get; set; }
        public int IdMiembroFamilia { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}

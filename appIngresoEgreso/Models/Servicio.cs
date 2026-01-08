namespace appIngresoEgreso.Models
{
    public class Servicio
    {
        public int ServicioId { get; set; }
        public string Nombre { get; set; }
        public string Empresa { get; set; }
        public DateOnly FechaRegistro { get; set; }
        public string Estado { get; set; }
    }
}

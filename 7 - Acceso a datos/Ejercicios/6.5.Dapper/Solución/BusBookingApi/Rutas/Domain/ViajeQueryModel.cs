namespace BusBookingApi.Rutas.Domain
{
    public class ViajeQueryModel
    {
        public int Id { get; set; }

        public DateTime Salida { get; set; }

        public DateTime Llegada { get; set; }
    }
}

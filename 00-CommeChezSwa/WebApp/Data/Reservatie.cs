using MessagePack;

namespace WebApp.Data
{
    public class Reservatie
    {
        public int ReservatieID { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public string? Email { get; set; }
        //public string? EmailBevestigen { get; set; }
        public DateTime? DatumReservatie { get; set; }
        public int? AantalPersonen { get; set; }
        //public bool NotARobot { get; set; }
        public Tijdslot Tijdslot { get; set; }
    }
}

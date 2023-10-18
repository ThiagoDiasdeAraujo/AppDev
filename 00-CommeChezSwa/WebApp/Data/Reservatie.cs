using MessagePack;

namespace WebApp.Data
{
    public class Reservatie
    {
        public string? Voornaam { get; set; }
        public string? Familienaam { get;}
        public string? Email { get; set; }
        public string? EmailBevestigen { get; set; }
        public DateTime? DatumReservatie { get; set; }
        public int? AantalPersonen { get; set; }
        public bool GaatAkkoordMetVoorwaarden { get; set; }
    }
}

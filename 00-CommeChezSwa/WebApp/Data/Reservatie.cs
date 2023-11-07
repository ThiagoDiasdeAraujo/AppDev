using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Data
{
    public class Reservatie
    {
        public int ReservatieID { get; set; }

        public string Voornaam { get; set; }

        [Display(Name = "Aantal Personen")]
        public string Familienaam { get; set; }

        public string? Email { get; set; }

        //public string? EmailBevestigen { get; set; }

        [Display(Name = "Datum Reservatie")]

        public DateTime? DatumReservatie { get; set; }

        [Display(Name = "Aantal Personen")]
        public int? AantalPersonen { get; set; }

        //public bool NotARobot { get; set; }

        public Tijdslot Tijdslot { get; set; }
    }
}

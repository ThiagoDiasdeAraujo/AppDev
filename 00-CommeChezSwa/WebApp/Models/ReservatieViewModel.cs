using Humanizer;
using System.ComponentModel.DataAnnotations;
using WebApp.Data;
using WebApp.Validations;


namespace WebApp.Models
{
    public class ReservatieViewModel
    {
        public Reservatie? Reservatie { get; set; } 


        [Required(ErrorMessage = "Voornaam is verplicht")]
        [MaxLength(50)]
        public string? Voornaam { get; set; }

        [Required(ErrorMessage = "Familie is verplicht")]
        [MaxLength(50)]
        public string? Familienaam { get; set; }

        [Required(ErrorMessage = "E-mailadres is verplicht")]
        [EmailAddress(ErrorMessage = "Ongeldig e-mailadres")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Bevestiging van e-mailadres is verplicht")]
        [EmailAddress]
        [Compare("Email", ErrorMessage = "E-mailadressen komen niet overeen")]
        [Display(Name = "Bevestig je email")]
        public string? EmailBevestigen { get; set; }

        [Required(ErrorMessage = "Datum is verplicht")]
        [DataType(DataType.Date)]
        public DateTime? DatumReservatie { get; set; }

        [Required(ErrorMessage = "Aantal personen is verplicht")]
        [Range(1, 10)]
        public int AantalPersonen { get; set; }

        [ExpectedValue(true, ErrorMessage = "Robots are not allowed to view this page")]
        [Display(Name = "Ik ben geen robot")]
        public bool NotARobot { get; set; }

        [Required]
        public Tijdslot Tijdslot { get; set; }


    }
}

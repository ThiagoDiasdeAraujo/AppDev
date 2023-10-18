using Humanizer;
using System.ComponentModel.DataAnnotations;
using WebApp.Data;

namespace WebApp.Models
{
    public class CreateReservationModel
    {
        [Required]
        [MaxLength(50)]
        public string? Voornaam { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Familienaam { get; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [EmailAddress]
        [Compare("Email")]
        [Display(Name = "Bevestig email")]
        public string? EmailBevestigen { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? DatumReservatie { get; set; }

        [Required]
        [Range(1, 10)] 
        public int AantalPersonen { get; set; }

        [Required]
        [Display(Name = "Ik ga akkoord met de algemene voorwaarden")]
        public bool NotARobot { get; set; }

        [Required]
        public Tijdslot Tijdslot { get; set; }

    }
}

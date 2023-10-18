using System.ComponentModel.DataAnnotations;

namespace Formulier.Models
{
    public class BookModel
    {
        [Required]
        [MaxLength(100)]
        public string? Title { get; set; }

        [MaxLength(100)]
        public string? Author { get; set; }

        [Required]
        [Display(Name = "ISBN-13 nummer")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Moet 13 lang zijn")]
        public string? ISBN { get; set; }

        [Required]
        public string? Genre { get; set; }

        [Required]
        public double? Price { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Release date")]
        public DateTime? ReleaseDate { get; set; }
    }
}

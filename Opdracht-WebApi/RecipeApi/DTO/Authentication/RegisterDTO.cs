using System.ComponentModel.DataAnnotations;

namespace RecipeApi.DTO.Authentication
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public bool IsAdmin { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace SportStore.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        [PersonalData]
        public string BirthDate { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace AuthenticatieEnAutorisatie.Authentication
{
    public class CustomUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string Lastname { get; set; }
    }
}

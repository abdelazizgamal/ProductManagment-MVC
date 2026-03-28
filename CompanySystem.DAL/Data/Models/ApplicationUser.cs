using Microsoft.AspNetCore.Identity;

namespace CompanySystem.DAL
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

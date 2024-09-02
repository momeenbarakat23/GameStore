using Microsoft.AspNetCore.Identity;

namespace store.Models
{
    public class AppUser :IdentityUser
    {

        public string? Address { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace api.Entities;

public class AppUser : IdentityUser
{
    public string FullName { get; set; }
    public string Title { get; set; }
    public string Address { get; set; }
}
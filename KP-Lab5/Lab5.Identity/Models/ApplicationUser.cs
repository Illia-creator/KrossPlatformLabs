using Microsoft.AspNetCore.Identity;

namespace Lab5.Identity.Models;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
}

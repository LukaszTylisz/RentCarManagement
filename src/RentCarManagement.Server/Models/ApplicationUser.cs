using Microsoft.AspNetCore.Identity;

namespace RentCarManagement.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
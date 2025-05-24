using Microsoft.AspNetCore.Identity;

namespace BuiThiPhuongThao.Models;

public class AppUser: IdentityUser
{
    public string? FullName { get; set; }
}

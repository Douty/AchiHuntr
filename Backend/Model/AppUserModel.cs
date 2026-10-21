
namespace AchiHunter.Backend.Model;

using Microsoft.AspNetCore.Identity;

public class AppUserModel : IdentityUser
{
    public DateTime CreatedDate {get; set; } = DateTime.UtcNow;
    public int UserPoints {get; set;}
    public List<PlatformAccount> PlatformAccounts {get; set;} = new();
}
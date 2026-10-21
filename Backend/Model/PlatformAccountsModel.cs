namespace AchiHunter.Backend.Model;

public enum Platforms
{
    Xbox = 1,
    PlayStation = 2,
    Steam = 3
}

public class PlatformAccount
{
    public int Id {get; set;}
    public string? UserId {get; set;}
    public required AppUserModel User {get; set;} 

    public Platforms Platform {get; set;}
    public required string? PlatformUserId {get; set;}
    public string? DisplayName {get; set;}
    public DateTime LinkedDate {get; set;} = DateTime.UtcNow;
}
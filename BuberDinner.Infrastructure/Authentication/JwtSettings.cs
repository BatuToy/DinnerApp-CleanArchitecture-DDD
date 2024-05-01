namespace BuberDinner.Infrastructre.Authentication;

public class JwtSettings 
{   public const string SectionName = "JwtSettings";
    public string Audiance { get; init; }  = null!;
    public string Issuer { get; init; }  = null!;
    public string Secret { get; init; } = null!;
    public int ExpiryMinutes { get; init; }
}
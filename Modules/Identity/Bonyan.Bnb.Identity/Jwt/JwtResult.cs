namespace Bonyan.Bnb.Identity.Jwt;

public class JwtResult
{
    public string AccessToken { get; set; }
    public DateTime ExpiredAt { get; set; }
}
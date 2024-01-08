namespace Bonyan.BNB.Identity.Application.Contracts.Jwt.Dtos;

public class AuthenticationJwtDto
{
    public string RefreshToken { get; set; }
    public string AccessToken { get; set; }
    public DateTime ExpireAt { get; set; }
}
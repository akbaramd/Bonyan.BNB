namespace Bonyan.BNB.Identity.Application.Contracts.Jwt.Dtos;

public class AuthenticationJwtLoginDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
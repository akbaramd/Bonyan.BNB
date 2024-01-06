using Bonyan.BNB.DDD.Application.Dtos;

namespace Bonyan.BNB.Identity.Application.Contracts.Users.Dtos;

public class UserCreateDto 
{
    public string UserName { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}

using Bonyan.BNB.DDD.Domain.Auditing;
using Bonyan.BNB.Identity.Domain.Roles;

namespace Bonyan.BNB.Identity.Domain.Users;
public class User : FullAuditedAggregateRoot<Guid>
{
    public string UserName { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }

    public ICollection<Role> Roles { get; set; }
}
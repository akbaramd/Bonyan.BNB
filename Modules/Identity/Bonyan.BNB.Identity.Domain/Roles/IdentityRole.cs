using Bonyan.BNB.DDD.Domain.Entities;
using Bonyan.BNB.Identity.Domain.Users;

namespace Bonyan.BNB.Identity.Domain.Roles;

public class IdentityRole : BnbEntity<Guid>
{
    public string Title { get; set; }   
    public string Name { get; set; }  
    
    
    public ICollection<IdentityUser> Users { get; set; }
}
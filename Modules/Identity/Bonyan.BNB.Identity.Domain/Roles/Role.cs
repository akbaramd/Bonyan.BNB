using Bonyan.BNB.DDD.Domain.Entities;
using Bonyan.BNB.Identity.Domain.Users;

namespace Bonyan.BNB.Identity.Domain.Roles;

public class Role : BnbEntity<Guid>
{
    public string Title { get; set; }   
    public string Name { get; set; }  
    
    
    public ICollection<User> Users { get; set; }
}
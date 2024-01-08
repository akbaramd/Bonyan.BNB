using Bonyan.BNB.Identity.Domain.Roles;
using Bonyan.BNB.Identity.Domain.Users;

namespace Bonyan.BNB.Identity.Domain.DomainServices;

public class IdentityUserManager(IIdentityUserRepository identityUserRepository)
{
    public Task<IdentityUser?> FindByRefreshTokenAsync(string refreshToken)
    {
        return identityUserRepository.FindOneAsync(x => x.RefreshToken.Equals(refreshToken));
    }
    public Task<IdentityUser> GetByUserNameAsync(string userName)
    {
        return identityUserRepository.GetOneAsync(x => x.UserName.Equals(userName));
    }
    public  Task<IdentityUser> GetByIdAsync(Guid id){
        return identityUserRepository.GetOneAsync(x => x.Id.Equals(id));
    }
    
    public async Task<bool> ExistByUserNameAsync(string userName){
        var find =  await identityUserRepository.FindOneAsync(x => x.UserName.Equals(userName));
        return find != null;
    }
    public async Task<bool> ComparePassword(IdentityUser user,string password){
        
        return user.Password.Equals(password);
    }
    public async Task<bool> ExistByIdAsync(Guid id)
    {
        var find =  await identityUserRepository.FindOneAsync(x => x.Id.Equals(id));
        return find != null;
    }

    public async Task CreateAsync(IdentityUser identityUser)
    {
        await identityUserRepository.InsertAsync(identityUser);
    }

    public async Task UpdateAsync(IdentityUser identityUser)
    {
        await identityUserRepository.UpdateAsync(identityUser);
    }

    public async Task DeleteAsync(IdentityUser identityUser)
    {
        await identityUserRepository.DeleteAsync(identityUser);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        await identityUserRepository.DeleteAsync(id);
    }
    
    public async Task<List<IdentityRole>> GetUserRolesByIdAsync(Guid id)
    {
        var user = await GetByIdAsync(id);
        return user.Roles.ToList();
    }
}
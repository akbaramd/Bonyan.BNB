using Bonyan.BNB.Identity.Domain.Roles;
using Bonyan.BNB.Identity.Domain.Users;

namespace Bonyan.Example.Domain.DomainServices;

public class UserManager
{
    private readonly IUserRepository _userRepository;

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<User> GetByUserNameAsync(string userName)
    {
        return _userRepository.GetOneAsync(x => x.UserName.Equals(userName));
    }
    public  Task<User> GetByIdAsync(Guid id){
        return _userRepository.GetOneAsync(x => x.Id.Equals(id));
    }
    
    public async Task<bool> ExistByUserNameAsync(string userName){
        var find =  await _userRepository.FindOneAsync(x => x.UserName.Equals(userName));
        return find != null;
    }

    public async Task<bool> ExistByIdAsync(Guid id)
    {
        var find =  await _userRepository.FindOneAsync(x => x.Id.Equals(id));
        return find != null;
    }

    public async Task CreateAsync(User user)
    {
        await _userRepository.InsertAsync(user);
    }

    public async Task UpdateAsync(User user)
    {
        await _userRepository.UpdateAsync(user);
    }

    public async Task DeleteAsync(User user)
    {
        await _userRepository.DeleteAsync(user);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        await _userRepository.DeleteAsync(id);
    }
    
    public async Task<List<Role>> GetUserRolesByIdAsync(Guid id)
    {
        var user = await GetByIdAsync(id);
        return user.Roles.ToList();
    }
}
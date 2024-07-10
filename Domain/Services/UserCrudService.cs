using System.Collections.Generic;
using System.Threading.Tasks;
using GitHubBase.ApplicationLayer.Services;
using GitHubBase.Domain.Entities;

namespace GitHubBase.Domain.Services;

public class UserCrudService : IUserCrudService
{
    public async Task<IList<User>> GetUsersAsync()
    {
        throw new System.NotImplementedException();
    }

    public async Task<User> GetUserAsync(int id)
    {
        throw new System.NotImplementedException();
    }

    public async Task AddUserAsync(User user)
    {
        throw new System.NotImplementedException();
    }

    public async Task UpdateUserAsync(User user)
    {
        throw new System.NotImplementedException();
    }

    public async Task DeleteUserAsync(User user)
    {
        throw new System.NotImplementedException();
    }
}
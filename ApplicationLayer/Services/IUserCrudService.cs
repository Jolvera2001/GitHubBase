using System.Collections.Generic;
using System.Threading.Tasks;
using GitHubBase.Domain.Entities;

namespace GitHubBase.ApplicationLayer.Services;

public interface IUserCrudService
{
    Task<IList<User>> GetUsersAsync();
    Task<User> GetUserAsync(int id);
    Task AddUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(User user);
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHubBase.ApplicationLayer.Services;
using GitHubBase.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GitHubBase.Domain.Services;

public class UserCrudService(SqliteService sqliteService) : IUserCrudService
{
    private readonly SqliteService _sqliteService = sqliteService ?? throw new ArgumentNullException(nameof(sqliteService));

    public async Task<IList<User>> GetUsersAsync()
    {
        return await _sqliteService.Users.ToListAsync();
    }

    public async Task<User?> GetUserAsync(int id)
    {
        return await _sqliteService.Users.FindAsync(id);
    }

    public async Task AddUserAsync(User user)
    {
        await _sqliteService.Users.AddAsync(user);
        await _sqliteService.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        _sqliteService.Entry(user).State = EntityState.Modified;
        await _sqliteService.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(User user)
    {
        _sqliteService.Users.Remove(user);
        await _sqliteService.SaveChangesAsync();
    }
}
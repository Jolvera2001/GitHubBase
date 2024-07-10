using System.Threading;
using System.Threading.Tasks;
using GitHubBase.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GitHubBase.ApplicationLayer.Services;

public interface ISqliteService
{
    DbSet<User> Users { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
}
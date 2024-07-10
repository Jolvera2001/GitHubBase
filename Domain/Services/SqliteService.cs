using System.Threading.Tasks;
using GitHubBase.ApplicationLayer.Services;
using GitHubBase.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GitHubBase.Domain.Services;

public class SqliteService : DbContext, ISqliteService
{
    public DbSet<User> Users { get; set; }

    public SqliteService(DbContextOptions<SqliteService> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=githubbase.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Users");
    }
}
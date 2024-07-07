using System;
using Microsoft.EntityFrameworkCore;

namespace GitHubBase.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string? AccountNickname { get; set; }
    public string? GitHubUsername { get; set; }
    public string? AccessToken { get; set; }
    public DateTime AccessTokenExpiration { get; set; }
}

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=githubbase.db");
    }
}
using GitHubBase.ApplicationLayer.Services;
using GitHubBase.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace GitHubBase.Domain.Services;

public class SqliteService : DbContext, ISqliteService
{
    public SqliteService(DbContextOptions<SqliteService> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "githubbase.db");
        optionsBuilder.UseSqlite($"Filename={dbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
        });
    }
}
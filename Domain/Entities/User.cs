using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GitHubBase.Domain.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    public string? AccountNickname { get; set; }
    public string? GitHubUsername { get; set; }
    public string? AccessToken { get; set; }
    public DateTime AccessTokenExpiration { get; set; }
}
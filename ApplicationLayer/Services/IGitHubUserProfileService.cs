using System.Threading.Tasks;

namespace GitHubBase.ApplicationLayer.Services;

public interface IGitHubUserProfileService
{
    Task<Octokit.User> GetUserProfileAsync(string username);
}
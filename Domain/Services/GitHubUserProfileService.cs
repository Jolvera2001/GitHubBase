using System.Threading.Tasks;
using GitHubBase.ApplicationLayer.Services;
using Octokit;

namespace GitHubBase.Domain.Services;

public class GitHubUserProfileService(IGitHubService githubService) : IGitHubUserProfileService
{
    private readonly IGitHubService _githubService = githubService;
    public async Task<Octokit.User> GetUserProfileAsync(string username)
    {
        GitHubClient client = await _githubService.GetClientAsync();
        return await client.User.Get(username);
    }
}
using System.Threading.Tasks;
using Octokit;

namespace GitHubBase.ApplicationLayer.Services;

public interface IGitHubService
{
    string ClientId { get; }
    string ClientSecret { get; }

    void StartGithubLogin();
    Task<string> ListenForCallbackAsync();

    Task<GitHubClient> GetClientAsync();
}
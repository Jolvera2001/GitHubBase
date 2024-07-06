using System;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using GitHubBase.ApplicationLayer.Services;
using Microsoft.Extensions.Configuration;
using Octokit;

namespace GitHubBase.Domain.Services;

public class GitHubService(IConfiguration config) : IGitHubService
{
    public string ClientId { get; } = config["GitHub:ClientId"];
    public string ClientSecret { get; } = config["GitHub:clientSecret"];
    private GitHubClient Client { get; } = new GitHubClient(new ProductHeaderValue("GitHubBase"));
    private string? _expectedCsrfToken; 

    public void StartGithubLogin()
    {
       _expectedCsrfToken = GenerateCsrfToken();

       var request = new OauthLoginRequest(ClientId)
       {
           Scopes = { "user", "notifications" },
           State = _expectedCsrfToken
       };

       var oauthLoginUrl = Client.Oauth.GetGitHubLoginUrl(request);

       Process.Start(new ProcessStartInfo(oauthLoginUrl.ToString()) { UseShellExecute = true });
    }

    public async Task<string> ListenForCallbackAsync()
    {
        var listener = new HttpListener();
        listener.Prefixes.Add("http://127.0.0.1:1234/GHBaseCallback");
        listener.Start();

        var context = await listener.GetContextAsync();
        var request = context.Request;

        var code = request.QueryString["code"];
        var state = request.QueryString["state"];

        if (state != _expectedCsrfToken)
        {
            throw new Exception("CSRF token mismatch");
        }

        var accessToken = await ExchangeCodeForAccessTokenAsync(code);

        // displays a simple HTML page to the user
        using var response = context.Response;
        {
            var responseString = "<html><head><title>GitHub Login</title></head><body><h1>GitHub Login Successful</h1><p>You can now close this window.</p></body></html>";
            var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
        }

        listener.Stop();
        return accessToken;
    }

    private async Task<string> ExchangeCodeForAccessTokenAsync(string code)
    {
        var request = new OauthTokenRequest(ClientId, ClientSecret, code);
        var token = await Client.Oauth.CreateAccessToken(request);

        return token.AccessToken;
    }

    private static string GenerateCsrfToken()
    {
        using var rng = new RNGCryptoServiceProvider();
        var data = new byte[24];
        rng.GetBytes(data);
        return Convert.ToBase64String(data);
    }
}
using GitHubBase.ApplicationLayer.Services;
using MauiReactor;

namespace GitHubBase.Pages
{
    internal class MainPageState
    {
        public string Nickname { get; set; } = "";
        public string GitHubUsername { get; set; } = "";
        public string GitHubStatus { get; set; } = "Not logged in";
    }

    internal partial class MainPage : Component<MainPageState>
    {
        [Inject] 
        private readonly IGitHubService _gitHubService;

        public override VisualNode Render()
         => ContentPage(
                VStack(
                        Label("Nickname:"),
                        Entry()
                            .Placeholder("Nickname")
                            .OnTextChanged((s,e) => SetState(_ => _.Nickname = e.NewTextValue)),
                        Label("GitHub Username:"),
                        Entry()
                            .Placeholder("Username")
                            .OnTextChanged((s, e) => SetState(_ => _.GitHubUsername = e.NewTextValue)),
                        Button("Login with GitHub", StartLoginProcess), 
                        Label(State.GitHubStatus)
                )
                .VCenter()
                .HCenter()
                .Padding(25)
                .Spacing(10)
            );

        private async void StartLoginProcess()
        {
            _gitHubService.StartGithubLogin();
            string result = await _gitHubService.ListenForCallbackAsync();
            SetState(s => s.GitHubStatus = $"Log in Successful: {result}");
        }
    }
}
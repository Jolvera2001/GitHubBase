using GitHubBase.ApplicationLayer.Services;
using MauiReactor;

namespace GitHubBase.Pages
{
    internal class MainPageState
    {
        public int Counter { get; set; }
    }

    internal partial class MainPage : Component<MainPageState>
    {
        [Inject] 
        private IGitHubService _gitHubService;

        public override VisualNode Render()
         => ContentPage(
                VStack(
                    Label($"Counter: {State.Counter}"),
                    HStack(
                        Button("Increment", () => SetState(s => s.Counter++)),
                        Button("Decrement", () => SetState(s => s.Counter--))
                        )
                        .Spacing(10),
                    Button("Login with GitHub", _gitHubService.StartGithubLogin)
                )
                .VCenter()
                .Padding(15)
                .Spacing(10)
                .HCenter()
            );
    }
}
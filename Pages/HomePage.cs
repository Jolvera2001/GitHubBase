using GitHubBase.ApplicationLayer.Services;
using MauiReactor;
using Octokit;

namespace GitHubBase.Pages
{
    internal class HomePageState
    {
        public bool IsBusy { get; set; } = true;
        public User? User { get; set; }
    }

    internal partial class HomePage : Component<HomePageState>
    {
        [Inject]
        private readonly IGitHubService _gitHubService;

        protected override void OnMounted()
        {
            LoadUser();

            State.IsBusy = false;
            base.OnMounted();
        }

        public override VisualNode Render()
            => State.IsBusy
                ? ContentPage(
                    VStack(
                        ActivityIndicator()
                            .IsRunning(State.IsBusy)
                    )
                )
            : ContentPage(
                    ScrollView(
                        VStack(
                            Label("I am home!")
                                .FontSize(32)
                                .HCenter(),
                            Button("Go back to main", GoBack)
                        )
                        .VCenter()
                        .Spacing(25)
                        .Padding(30, 0)
                    )
                );

        private async void GoBack()
        { 
            await MauiControls.Shell.Current.GoToAsync("//MainPage");
        }

        private async void LoadUser()
        {
            State.User = await _gitHubService.GetUserAsync();
        }
    }
}

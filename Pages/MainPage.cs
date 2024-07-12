using GitHubBase.ApplicationLayer.Services;
using MauiReactor;

namespace GitHubBase.Pages
{
    internal class MainPageState
    {
        public bool IsBusy { get; set; } = true;
        public string Nickname { get; set; } = "";
        public string GitHubUsername { get; set; } = "";
        public string GitHubStatus { get; set; } = "Not logged in";
    }

    internal partial class MainPage : Component<MainPageState>
    {
        [Inject] 
        private readonly IGitHubService _gitHubService;

        protected override void OnMounted()
        {
            CredCheck();

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
                    HStack(
                            VStack(
                                    Button("Login with GitHub", StartLoginProcess)
                                )
                                .VCenter()
                                .HCenter()
                                .Padding(25)
                                .Spacing(10)
                        )
                        .Spacing(30)
                        .HCenter()
                );

        private async void StartLoginProcess()
        {
            _gitHubService.StartGithubLogin();
            string result = await _gitHubService.ListenForCallbackAsync();
            SetState(s => s.GitHubStatus = $"Log in Successful: {result}");
            CredCheck();
        }

        private async void GoHome()
        {
            await MauiControls.Shell.Current.GoToAsync("//HomePage");
        }

        private async void CredCheck()
        {
            var check = await _gitHubService.IsLoggedInAsync();
            if (check)
            {
                GoHome();
            }
        }
    }
}
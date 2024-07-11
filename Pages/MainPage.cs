using System.Collections.Generic;
using GitHubBase.ApplicationLayer.Services;
using GitHubBase.Domain.Entities;
using MauiReactor;

namespace GitHubBase.Pages
{
    internal class MainPageState
    {
        public bool isBusy { get; set; } = true;
        public string Nickname { get; set; } = "";
        public string GitHubUsername { get; set; } = "";
        public string GitHubStatus { get; set; } = "Not logged in";
        public List<User> Users { get; set; } = new List<User>();
    }

    internal partial class MainPage : Component<MainPageState>
    {
        [Inject] 
        private readonly IGitHubService _gitHubService;

        [Inject]
        private readonly IUserCrudService _userCrudService;

        protected override void OnMounted()
        {
            State.isBusy = true;

            SetState(FetchUsers);

            State.isBusy = false;
            base.OnMounted();
        }

        public override VisualNode Render()
            => State.isBusy
                ? ContentPage(
                    VStack(
                        ActivityIndicator()
                            .IsRunning(State.isBusy)
                        )
                    )
                : ContentPage(
                    HStack(
                            VStack(
                                    Label("Accounts"),
                                    CollectionView()
                                        .ItemsSource(State.Users, RenderAccounts),
                                    Button("Add Test Account", TestCrud)
                                )
                                .VCenter()
                                .HCenter()
                                .Padding(25)
                                .Spacing(10),
                            VStack(
                                    Label("Nickname:"),
                                    Entry()
                                        .Placeholder("Nickname")
                                        .OnTextChanged((s, e) => SetState(_ => _.Nickname = e.NewTextValue)),
                                    Label("GitHub Username:"),
                                    Entry()
                                        .Placeholder("Username")
                                        .OnTextChanged((s, e) => SetState(_ => _.GitHubUsername = e.NewTextValue)),
                                    Button("Login with GitHub", StartLoginProcess)
                                        .IsEnabled(!string.IsNullOrWhiteSpace(State.GitHubUsername) &&
                                                   !string.IsNullOrWhiteSpace(State.Nickname)),
                                    Label(State.GitHubStatus),
                                    Button("Nav to home", GoHome)
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
        }

        private async void GoHome()
        {
            await MauiControls.Shell.Current.GoToAsync("//HomePage");
        }

        private async void TestCrud()
        {
            User testUser = new User()
            {
                AccountNickname = "Test",
                GitHubUsername = "Test",
            };
            await _userCrudService.AddUserAsync(testUser);
            SetState(FetchUsers);
        }

        private async void FetchUsers(MainPageState s)
        {
            s.Users = await _userCrudService.GetUsersAsync();
        }

        private VisualNode RenderAccounts(User user)
            => VStack(
                Label(user.AccountNickname)
                    .FontSize(20),
                Label(user.GitHubUsername)
                    .FontSize(15)
            );
    }
}
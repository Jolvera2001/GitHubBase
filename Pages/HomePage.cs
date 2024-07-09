using MauiReactor;

namespace GitHubBase.Pages
{
    internal class HomePage : Component
    {
        public override VisualNode Render()
            => ContentPage(
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
    }
}

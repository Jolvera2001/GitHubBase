using MauiReactor;

namespace GitHubBase.Pages;

public class SearchPage : Component
{

    public override VisualNode Render()
        => ContentPage(
            ScrollView(
                VStack(
                    Label("Search Page!")
                        .FontSize(32)
                        .HCenter()
                )
                .VCenter()
                .Spacing(25)
                .Padding(30, 0)
            )
        );
    
}
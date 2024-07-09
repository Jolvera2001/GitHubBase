using GitHubBase.Pages;
using MauiIcons.Fluent;
using MauiReactor;
using Microsoft.Maui.Controls;

namespace GitHubBase
{
    internal class AppShell : Component
    {
        public override VisualNode Render()
            => Shell(
                    ShellContent()
                        .RenderContent(() => new MainPage())
                        .Route("MainPage"),
                    TabBar(
                        Tab(
                                ShellContent()
                                    .Title("HomePage")
                                    .RenderContent(() => new HomePage())
                                    .Route("HomePage")
                            )
                            .Icon("Home"),
                        Tab(
                                ShellContent()
                                    .Title("SearchPage")
                                    .RenderContent(() => new SearchPage())
                                    .Route("SearchPage")
                            )
                            .Icon("Search")
                    )
                )
                .FlyoutBehavior(FlyoutBehavior.Disabled);
    }

}

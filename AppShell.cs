using GitHubBase.Pages;
using MauiIcons.Material;
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
                                    .RenderContent(() => new HomePage())
                                    .Route("HomePage")
                            )
                            .Icon(new FontImageSource
                            {
                                Glyph = "\ue88a",
                                FontFamily = "MaterialOutlined",
                                Size = 18
                            }),
                        Tab(
                                ShellContent()
                                    .RenderContent(() => new SearchPage())
                                    .Route("SearchPage")
                            )
                            .Icon(new FontImageSource
                            {
                                Glyph = "\ue8b6",
                                FontFamily = "MaterialOutlined",
                                Size = 18
                            })
                    )
                )
                .FlyoutBehavior(FlyoutBehavior.Disabled);
    }

}

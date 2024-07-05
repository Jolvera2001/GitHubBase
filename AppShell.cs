using GitHubBase.Pages;
using MauiReactor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubBase
{
    internal class AppShell : Component
    {
        public override VisualNode Render()
            => Shell(
                FlyoutItem("MainPage",
                    ShellContent()
                        .Title("MainPage")
                        .RenderContent(() => new MainPage())
                ),
                FlyoutItem("OtherPage",
                    ShellContent()
                        .Title("OtherPage")
                        .RenderContent(() => new OtherPage())
                )
            );
    }

}

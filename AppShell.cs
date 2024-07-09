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
                ShellContent()
                    .Title("MainPage")
                    .RenderContent(() => new MainPage())
                    .Route("MainPage"),
                TabBar(
                    Tab(ShellContent()
                        .Title("HomePage")
                        .RenderContent(() => new HomePage())
                        .Route("HomePage")
                    )
                    .Icon("home")
                )
                
            );
    }

}

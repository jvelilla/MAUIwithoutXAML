
using Microsoft.Maui.Controls;

namespace ExampleMauiApp
{
    public class AppShellCsharp : Shell
    {
        public AppShellCsharp()
        {
            var shellContent = new ShellContent();
            shellContent.Title = "Hello World from ShellC#";

            var dataTemplate = new DataTemplate(typeof(MainPageCsharp));

            shellContent.ContentTemplate = dataTemplate;
            shellContent.Route = "MainPageCsharp";
            CurrentItem = shellContent;
        }
    }

}




using Microsoft.Maui.Controls;

namespace ExampleMauiApp
{
    public class AppShellCsharp : Shell
    {
        public AppShellCsharp()
        {
            var shellContent = new ShellContent();
            shellContent.Title = "StackLayout Example";

            var dataTemplate = new DataTemplate(typeof(StandardTipPage));

            shellContent.ContentTemplate = dataTemplate;
            shellContent.Route = "StandardTipPage";
            CurrentItem = shellContent;
            Routing.RegisterRoute(nameof(MainPageCsharp), typeof(MainPageCsharp));
        }
    }

}



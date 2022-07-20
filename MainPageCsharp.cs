
using Microsoft.Maui.Controls;

namespace ExampleMauiApp;
public class MainPageCsharp : ContentPage
{
    public MainPageCsharp()
    {
        var stack = new StackLayout();
        stack.Orientation = StackOrientation.Vertical;
        //stack.Orientation = StackOrientation.Horizontal;
        //does not work.
        stack.Spacing = 20;
        var a = new BoxView { Color = Colors.Silver, HeightRequest = 40 };
        var b = new BoxView { Color = Colors.Blue, HeightRequest = 40 };
        var c = new BoxView { Color = Colors.Gray, HeightRequest = 40 };

        stack.Children.Add(a);
        stack.Children.Add(b);
        stack.Children.Add(c);
        this.Content = stack;
    }

}
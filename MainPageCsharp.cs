
using Microsoft.Maui.Controls;
using static System.Net.Mime.MediaTypeNames;
using System;

namespace ExampleMauiApp;
public class MainPageCsharp : ContentPage
{
    //https://docs.microsoft.com/en-us/dotnet/maui/user-interface/layouts/grid
    public MainPageCsharp()
    {
        Grid grid = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
            },
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
            }
        };
        var boxView = new BoxView() {
            Color = Colors.Navy
        };

        grid.Add(boxView, 0, 1);
        //Grid.SetColumnSpan(boxView, 2);

        Title = "Basic Grid demo";
        Content = grid;
    }
}

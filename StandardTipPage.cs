using Microsoft.Maui;
using Microsoft.Maui.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace ExampleMauiApp;

public class StandardTipPage: ContentPage
{
    private Color colorNavy = Colors.Navy;
    private Color colorSilver = Colors.Silver;

    Entry billInput;
    Label totalOutput;
    Label tipOutput;
    Grid LayoutRoot;
    Label tipLabel;
    Label billLabel;
    Label totalLabel;
   
    public StandardTipPage()
    {
        LayoutRoot = new()
        {
            RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
               },
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) }
            },
            Padding = 10,
            BackgroundColor = Colors.Silver
        };


        billLabel = new Label()
        {
            Text = "Bill",
            TextColor = Colors.Navy,
            FontSize = 22,
            FontAttributes= FontAttributes.Bold,
        };

        billInput = new Entry()
        {
            Placeholder = "Enter Amount",
            Keyboard = Keyboard.Numeric,
            TextColor = Colors.Gray,
        };

        LayoutRoot.Add(billLabel, 0, 0);
        LayoutRoot.Add(billInput, 1, 0);

        tipLabel = new Label()
        {
            Text = "Tip",
            TextColor = Colors.Navy,
            FontSize = 22,    
            FontAttributes  =  FontAttributes.Bold,
        };
        tipOutput = new Label() { Text = "0.00", TextColor = Colors.Navy, FontSize = 22 };

        LayoutRoot.Add(tipLabel, 0, 1);
        LayoutRoot.Add(tipOutput, 1, 1);


        totalLabel = new Label()
        {
            Text = "Total",
            TextColor= Colors.Navy,
            FontAttributes = FontAttributes.Bold,
            FontSize = 22
        };
        totalOutput = new Label() { Text = "0.00", TextColor = Colors.Navy, FontSize = 22 };

        LayoutRoot.Add(totalLabel, 0, 2);
        LayoutRoot.Add(totalOutput, 1, 2);


        //Navigate to advanced-view page
        var customPageButton = new Button()
        {
            Text = "Use Custom Calculator",
            TextColor = Colors.White

        };
        LayoutRoot.SetColumnSpan(customPageButton, 2);
        customPageButton.Clicked += GotoCustom;

        LayoutRoot.Add(customPageButton, 0, 3);

        var buttonLight = new Button()
        {
            Text = "Light",
            TextColor = Colors.White
        };
        var buttonDark = new Button()
        {
            Text = "Dark",
            TextColor = Colors.White
        };

        buttonLight.Clicked += OnLight;
        buttonDark.Clicked += OnDark;

        //Swap the foreground/background colors of this page.
        HorizontalStackLayout horizontalLayout = new()
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.End,
            Spacing = 100
        };
        LayoutRoot.Add(horizontalLayout, 0, 4);
        Grid.SetColumnSpan(horizontalLayout, 2);
        horizontalLayout.Add(buttonLight);
        horizontalLayout.Add(buttonDark);
        Grid.SetColumn(buttonLight, 0);
        Grid.SetColumn(buttonDark, 1);


        this.Content = LayoutRoot;

        Title = "Grid Example with Pages";

        billInput.TextChanged += (s, e) => CalculateTip();
      }

    void CalculateTip()
    {
        double bill;

        if (Double.TryParse(billInput.Text, out bill) && bill > 0)
        {
            double tip = Math.Round(bill * 0.15, 2);
            double final = bill + tip;

            tipOutput.Text = tip.ToString("C");
            totalOutput.Text = final.ToString("C");
        }
    }

    void OnLight(object sender, EventArgs e)
    {
        LayoutRoot.BackgroundColor = colorSilver;

        tipLabel.TextColor = colorNavy;
        billLabel.TextColor = colorNavy;
        totalLabel.TextColor = colorNavy;
        tipOutput.TextColor = colorNavy;
        totalOutput.TextColor = colorNavy;
    }

    void OnDark(object sender, EventArgs e)
    {
        LayoutRoot.BackgroundColor = colorNavy;

        tipLabel.TextColor = colorSilver;
        billLabel.TextColor = colorSilver;
        totalLabel.TextColor = colorSilver;
        tipOutput.TextColor = colorSilver;
        totalOutput.TextColor = colorSilver;
    }

    async void GotoCustom(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(MainPageCsharp));
    }
}

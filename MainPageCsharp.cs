
using Microsoft.Maui.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace ExampleMauiApp;
public class MainPageCsharp : ContentPage
{
    Entry billInput;
    Slider tipPercentSlider;
    Label totalOutput;
    Label tipOutput;

    public MainPageCsharp()
    {
        Grid grid = new Grid()
        {
            RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) }
            },
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
            },
            Padding = 40
        };

     
        var billLabel = new Label()
        {
            Text = "Bill",
            WidthRequest = 100,
            VerticalOptions = LayoutOptions.Center
        };

        billInput = new Entry()
        {
            Placeholder = "Enter Amount",
            Keyboard = Keyboard.Numeric
        };

        grid.Add(billLabel, 0, 0);
        grid.Add(billInput, 1, 0);

        var labelTip = new Label()
        {
            Text = "Tip",
            WidthRequest = 100,
        };
        tipOutput = new Label() { Text = "0.00" };

        grid.Add(labelTip, 0, 1);
        grid.Add(tipOutput, 1, 1);


        var labelTotal = new Label()
        {
            Text = "Total",
            WidthRequest = 100
        };
        totalOutput = new Label() { Text = "0.00" };

        grid.Add(labelTotal, 0, 2);
        grid.Add(totalOutput, 1, 2);

        var tipPercentage = new Label()
        {
            Text = "Tip Percentage",
            VerticalOptions= LayoutOptions.End,
            HorizontalOptions = LayoutOptions.Start 
        };
        var labelTipPercentageOutput = new Label() { Text = "15%" };

        grid.Add(tipPercentage, 0, 3);
        grid.Add(labelTipPercentageOutput, 1, 3);

        tipPercentSlider = new Slider()
        {
            Minimum = 0,
            Maximum = 100,
            Value = 15,
        };

        grid.Add(tipPercentSlider, 0, 4);
        grid.SetColumnSpan(tipPercentage, 2);

        var buttonNormalTip = new Button()
        {
            Text = "15%",
            Margin = new Thickness(5)
        };
        buttonNormalTip.Clicked += OnNormalTipClicked;

        var buttonOGenerousTip = new Button()
        {
            Text = "20%",
            Margin = new Thickness(5)

        };

        grid.Add(buttonNormalTip, 0, 5);
        grid.Add(buttonOGenerousTip, 1, 5);


        buttonOGenerousTip.Clicked += OnGenerousTipClicked;

        var roundDown = new Button()
        {
            Text = "Round Down",
            Margin = new Thickness(5)
        };
        var roundUp = new Button()
        {
            Text = "Round Up",
            Margin = new Thickness(5)

        };

        grid.Add(roundDown, 0, 6);
        grid.Add(roundUp, 1, 6);    
        this.Content = grid;

        Title = "Grid Example";

        billInput.TextChanged += (s, e) => CalculateTip(false, false);
        roundDown.Clicked += (s, e) => CalculateTip(false, true);
        roundUp.Clicked += (s, e) => CalculateTip(true, false);
        tipPercentSlider.ValueChanged += (s, e) =>
        {
            double pct = Math.Round(e.NewValue);
            tipPercentage.Text = pct + "%";
            CalculateTip(false, false);
        };
    }

    void OnNormalTipClicked(object sender, EventArgs e)
    {
        tipPercentSlider.Value = 15;
    }
    void OnGenerousTipClicked(object sender, EventArgs e)
    {
        tipPercentSlider.Value = 20;
    }


    void CalculateTip(bool roundUp, bool roundDown)
    {
        double t;
        if (Double.TryParse(billInput.Text, out t) && t > 0)
        {
            double pct = Math.Round(tipPercentSlider.Value);
            double tip = Math.Round(t * (pct / 100.0), 2);

            double final = t + tip;

            if (roundUp)
            {
                final = Math.Ceiling(final);
                tip = final - t;
            }
            else if (roundDown)
            {
                final = Math.Floor(final);
                tip = final - t;
            }

            tipOutput.Text = tip.ToString("C");
            totalOutput.Text = final.ToString("C");
        }
    }
}

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
        var stack = new StackLayout()
        {
            Orientation = StackOrientation.Vertical,
            Padding = 40,
            Spacing = 10,
        };


        var horizontalLayout1 = new HorizontalStackLayout()
        {
            Spacing = 10
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
        horizontalLayout1.Children.Add(billLabel);
        horizontalLayout1.Children.Add(billInput);

        var horizontalLayout2 = new HorizontalStackLayout()
        {
            Margin =new Thickness(0, 20, 0, 0), 
            Spacing = 10
        };


        var labelTip = new Label() 
        { 
            Text = "Tip",
            WidthRequest= 100,
        };
        tipOutput = new Label() { Text = "0.00" };

        horizontalLayout2.Children.Add(labelTip);
        horizontalLayout2.Children.Add(tipOutput);

        var horizontalLayout3 = new HorizontalStackLayout()
        {
            Spacing = 10
        };

        var labelTotal = new Label() 
        { 
            Text = "Total",
            WidthRequest = 100
        };
        totalOutput = new Label() { Text = "0.00" };

        horizontalLayout3.Children.Add(labelTotal);
        horizontalLayout3.Children.Add(totalOutput);

        var horizontalLayout4 = new HorizontalStackLayout()
        {
            Spacing = 10
        };

        var tipPercentage = new Label() 
        { 
            Text = "Tip Percentage",
            WidthRequest = 100
        };
        var labelTipPercentageOutput = new Label() { Text = "15%" };

        horizontalLayout4.Children.Add(tipPercentage);
        horizontalLayout4.Children.Add(labelTipPercentageOutput);

        tipPercentSlider = new Slider()
        {
            Minimum = 0,
            Maximum = 100,
            Value = 15,
        };
       
        stack.Children.Add(horizontalLayout1);
        stack.Children.Add(horizontalLayout2);
        stack.Children.Add(horizontalLayout3);
        stack.Children.Add(horizontalLayout4);
        stack.Children.Add(tipPercentSlider);

  
        var buttonNormalTip = new Button()
        {
            Text = "15%",
            WidthRequest= 150,
            HorizontalOptions = LayoutOptions.CenterAndExpand
        };
        buttonNormalTip.Clicked += OnNormalTipClicked;

        var buttonOGenerousTip = new Button()
        {
            Text = "20%",
            WidthRequest = 150,
            HorizontalOptions = LayoutOptions.CenterAndExpand

        };

        var horizontalLayout5 = new HorizontalStackLayout()
        {
            Margin = new Thickness(0,20, 0, 0),
            Spacing = 10
        };
        horizontalLayout5.Children.Add(buttonNormalTip);
        horizontalLayout5.Children.Add(buttonOGenerousTip);  
            



        buttonOGenerousTip.Clicked += OnGenerousTipClicked;

        var roundDown = new Button()
        {
            Text = "Round Down",
            WidthRequest = 150,
            HorizontalOptions = LayoutOptions.CenterAndExpand
        };
        var roundUp = new Button()
        {
            Text = "Round Up",
            WidthRequest = 150,
            HorizontalOptions = LayoutOptions.CenterAndExpand

        };
        var horizontalLayout6 = new HorizontalStackLayout()
        {
            Margin = new Thickness(0, 20, 0, 0),
            Spacing = 10
        };
        horizontalLayout6.Children.Add(roundDown);
        horizontalLayout6.Children.Add(roundUp);

        stack.Children.Add(horizontalLayout5);
        stack.Children.Add(horizontalLayout6); 
                 
        this.Content = stack;

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
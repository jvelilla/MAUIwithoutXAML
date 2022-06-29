using Microsoft.Maui;
using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ExampleMauiApp.WinUI;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
/// At the moment this code does not compile.
/// Compile error: CS5001: Program does not contain a static 'Main' method suitable for an entry point
public class App : MauiWinUIApplication
{
	/// <summary>
	/// Initializes the singleton application object.  This is the first line of authored code
	/// executed, and as such is the logical equivalent of main() or WinMain().
	/// </summary>
	public App()
	{
    }

    //static void Main(string[] args)
    //{
    //   var app = new App();
    //}

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}


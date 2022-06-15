

using System.Reflection;

namespace ExampleMauiApp
{
    class AppCSharp : Application
    {
        public AppCSharp()
        {
            var colors = new Uri("file://Resources/Styles/Colors.xaml", UriKind.RelativeOrAbsolute);
            var styles = new Uri("file://Resources/Styles/Styles.xaml", UriKind.RelativeOrAbsolute);
            //https://stackoverflow.com/questions/50651949/source-can-only-be-set-from-xaml 
            var source = new Uri("/Resources/Styles/Colors.xaml", UriKind.RelativeOrAbsolute);
            var resourceDictionary = new ResourceDictionary();
            resourceDictionary.SetAndLoadSource(source, "Resources/Styles/Colors.xaml", this.GetType().GetTypeInfo().Assembly, null);
            Resources.MergedDictionaries.Add(resourceDictionary);
            Resources.MergedDictionaries.ElementAt(0).Source = source;

            source = new Uri("/Resources/Styles/Styles.xaml", UriKind.RelativeOrAbsolute);
            resourceDictionary = new ResourceDictionary();
            resourceDictionary.SetAndLoadSource(source, "Resources/Styles/Styles.xaml", this.GetType().GetTypeInfo().Assembly, null);
            Resources.MergedDictionaries.Add(resourceDictionary);
            Resources.MergedDictionaries.ElementAt(1).Source = source;

            MainPage = new AppShellCsharp();
        }

    }
}

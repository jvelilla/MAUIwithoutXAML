

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


            var resources = new ResourceDictionary
              {
                { "bgColor", Colors.Navy },
                { "fgColor", Colors.Silver}
            };

            // Define a Base Style
            var baseLabelStyle = new Style(typeof(Label));
            // Define a setter for FontSize
            Setter fontSize = new Setter();
            fontSize.Property = Label.FontSizeProperty;
            fontSize.Value = 22;
            //Add the setters to the base style.
            baseLabelStyle.Setters.Add(fontSize);



            // Define a Style for a label and set the to `infoLabelStyle`
            var infoLabelStyle = new Style(typeof(Label));
            // use style inheritance
            infoLabelStyle.BasedOn = baseLabelStyle;

            // Define a setter for FontAttribute
            Setter fontAttribtuesSetter = new Setter();
            fontAttribtuesSetter.Property = Label.FontAttributesProperty;
            fontAttribtuesSetter.Value = FontAttributes.Bold;


            //Add the setters to the style.
            infoLabelStyle.Setters.Add(fontAttribtuesSetter);

            // Add the styles to the resource page.
            resources.Add("baseLabelStyle", baseLabelStyle);
            resources.Add("infoLabelStyle", infoLabelStyle);


            
            Resources.Add(resources);


            MainPage = new AppShellCsharp();
        }

    }
}

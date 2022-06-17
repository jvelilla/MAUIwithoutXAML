# MAUIwithoutXAML
Simple MAUI example without using XAML

Inspired by https://github.com/jfversluis/MauiCSharpMarkupExample

## Changes to the NET MAUI template project.
  * AppCSharp.cs replaces [App.xaml, App.xaml.css]
  * AppShellCsharp.cs replaces [AppShell.xaml, AppShell.xaml.cs]
  * MainPageCsharp.cs replaces [MainPage.xaml, MainPage.xaml.cs]
  * MauiProgram.cs now call AppCSharp.

`MauiProgram.cs`: code for creating and configuring the Application Object.
`AppCSharp.cs`: create the initial window for the Application.
`AppShellCsharp.cs`: intial page for the application and handle the registration of pages for navigation routing.
`MainPageCsharp.cs`: define the layout and UI logic for the page displayed in the initial window.



### Application:
Represents the cross plarform mobile application.
AppCSharp.cs inherit from Microsoft.Maui.Controls.Application.

### Shell
Page that provide fundamental UI features that most APP require.
AppShellCsharp.cs inherit from Microsoft.Maui.Controls.Shell

### Pages
Pages are the root of the UI hierarchy inside of a Shell.
MainPageCsharp.cs inherit from Microsoft.Maui.Controls.ContentPage, it's a `page` that display
a single view. `ContentPage` is one of the built-in page types offered by Net MAUI.


### Views
A content page typically displays a view (a way to retrieve and present the data).
Examples: `ContentView`, `ScrollView` (this one it's used in the current example).


### Controls and Layout
Views can contain a single control (button, label or text). A view is itself a control, so can 
contain another view.
Controls are positioned in a layout. A layout defines rules by which controls are displayed relative 
to each other. A layout is a control.

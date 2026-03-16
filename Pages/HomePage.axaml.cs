using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;

namespace StudentsAvalonia.Pages;

public partial class HomePage : Window
{
    public HomePage()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void BtnExit_Click(object? sender, RoutedEventArgs e)
    {
        AuthPage authPage = new AuthPage();
        authPage.Show();
        Close();
    }
}
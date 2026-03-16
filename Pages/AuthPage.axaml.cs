using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;

namespace StudentsAvalonia.Pages;

public partial class AuthPage : Window
{
    public AuthPage()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void BtnLogin_Click(object? sender, RoutedEventArgs e)
    {
        HomePage homePage = new HomePage();
        homePage.Show();
        Close();
    }

    private void BtnOpenReg_Click(object? sender, RoutedEventArgs e)
    {
        RegistPage registPage = new RegistPage();
        registPage.Show();
        Close();
    }
}
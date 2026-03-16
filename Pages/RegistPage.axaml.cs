using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;

namespace StudentsAvalonia.Pages;

public partial class RegistPage : Window
{
    public RegistPage()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void BtnReg_Click(object? sender, RoutedEventArgs e)
    {
        AuthPage authPage = new AuthPage();
        authPage.Show();
        
        Close();
    }

    private void BtnBack_Click(object? sender, RoutedEventArgs e)
    {
        AuthPage authPage = new AuthPage();
        authPage.Show();
        Close();
    }
}
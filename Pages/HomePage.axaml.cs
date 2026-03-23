using Avalonia.Controls;
using Avalonia.Interactivity;
using StudentsAvalonia.Controls;

namespace StudentsAvalonia.Pages;

public partial class HomePage : Window
{
    public HomePage()
    {
        InitializeComponent();
        MainContent.Content = new StudentsControl();
    }

    private void Students_Click(object? sender, RoutedEventArgs e)
    {
        MainContent.Content = new StudentsControl();
    }

    private void Groups_Click(object? sender, RoutedEventArgs e)
    {
        MainContent.Content = new GroupsControl();
    }

    private void Spec_Click(object? sender, RoutedEventArgs e)
    {
        MainContent.Content = new SpecialitiesControl();
    }
}
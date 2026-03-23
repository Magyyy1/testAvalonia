using Avalonia.Controls;
using Avalonia.Interactivity;
using StudentsAvalonia.Classes;
using StudentsAvalonia.Windows;
using System.Linq;

namespace StudentsAvalonia.Controls;

public partial class SpecialitiesControl : UserControl
{
    public SpecialitiesControl()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        SpecialityGrid.ItemsSource = ConnectionClass.connect.Specialities.ToList();
    }

    private async void Add_Click(object? sender, RoutedEventArgs e)
    {
        AddSpecialityWindow window = new AddSpecialityWindow();
        await window.ShowDialog((Window)VisualRoot!);
        LoadData();
    }

    private void Refresh_Click(object? sender, RoutedEventArgs e)
    {
        LoadData();
    }
}
using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Microsoft.EntityFrameworkCore;
using StudentsAvalonia.Classes;
using StudentsAvalonia.Windows;
using System.Linq;

namespace StudentsAvalonia.Controls;

public partial class StudentsControl : UserControl
{
    public StudentsControl()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        StudentGrid.ItemsSource = ConnectionClass.connect.Users
            .Include(x => x.Group!)
            .ThenInclude(x => x.Speciality)
            .ToList();
    }

    private async void Add_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            AddStudentWindow window = new AddStudentWindow();

            if (VisualRoot is Window owner)
            {
                await window.ShowDialog(owner);
            }
            else if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop && desktop.MainWindow != null)
            {
                await window.ShowDialog(desktop.MainWindow);
            }
            else
            {
                await window.ShowDialog();
            }

            LoadData();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"StudentsControl.Add_Click error: {ex}");
            throw;
        }
    }

    private void Refresh_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            LoadData();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"StudentsControl.Refresh_Click error: {ex}");
            throw;
        }
    }
}
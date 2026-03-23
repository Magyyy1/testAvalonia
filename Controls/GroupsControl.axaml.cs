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

public partial class GroupsControl : UserControl
{
    public GroupsControl()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        GroupGrid.ItemsSource = ConnectionClass.connect.Groups
            .Include(x => x.Speciality)
            .ToList();
    }

    private async void Add_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            AddGroupWindow window = new AddGroupWindow();

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
            Console.WriteLine($"GroupsControl.Add_Click error: {ex}");
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
            Console.WriteLine($"GroupsControl.Refresh_Click error: {ex}");
            throw;
        }
    }
}
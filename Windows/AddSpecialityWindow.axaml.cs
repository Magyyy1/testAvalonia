using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using StudentsAvalonia.Classes;
using StudentsAvalonia.Data;

namespace StudentsAvalonia.Windows;

public partial class AddSpecialityWindow : Window
{
    public AddSpecialityWindow()
    {
        InitializeComponent();
    }

    private void Save_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text))
            {
                return;
            }

            Speciality speciality = new Speciality
            {
                NameSpeciality = NameBox.Text,
                Description = DescriptionBox.Text
            };

            ConnectionClass.connect.Specialities.Add(speciality);
            ConnectionClass.connect.SaveChanges();

            Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"AddSpecialityWindow.Save_Click error: {ex}");
            throw;
        }
    }

    private void Close_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"AddSpecialityWindow.Close_Click error: {ex}");
            throw;
        }
    }
}
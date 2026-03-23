using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using StudentsAvalonia.Classes;
using StudentsAvalonia.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsAvalonia.Windows;

public partial class AddGroupWindow : Window
{
    public AddGroupWindow()
    {
        InitializeComponent();
        LoadSpecialities();
    }

    private void LoadSpecialities()
    {
        SpecialityBox.ItemsSource = ConnectionClass.connect.Specialities.ToList();
    }

    private void Save_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(NumberBox.Text) ||
                SpecialityBox.SelectedItem == null)
            {
                return;
            }

            Speciality speciality = (Speciality)SpecialityBox.SelectedItem!;

            Group group = new Group
            {
                Number = NumberBox.Text,
                Description = DescriptionBox.Text,
                IdSpeciality = speciality.IdSpeciality
            };

            ConnectionClass.connect.Groups.Add(group);
            ConnectionClass.connect.SaveChanges();

            Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"AddGroupWindow.Save_Click error: {ex}");
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
            Console.WriteLine($"AddGroupWindow.Close_Click error: {ex}");
            throw;
        }
    }

    internal async Task ShowDialog()
    {
        throw new NotImplementedException();
    }
}
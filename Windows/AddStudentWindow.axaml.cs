using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.EntityFrameworkCore;
using StudentsAvalonia.Classes;
using StudentsAvalonia.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsAvalonia.Windows;

public partial class AddStudentWindow : Window
{
    public AddStudentWindow()
    {
        InitializeComponent();
        LoadGroups();
    }

    private void LoadGroups()
    {
        GroupBox.ItemsSource = ConnectionClass.connect.Groups
            .Include(x => x.Speciality)
            .ToList();
    }

    private void GroupBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        Group? group = GroupBox.SelectedItem as Group;

        if (group != null)
        {
            SpecialityBox.Text = group.Speciality?.NameSpeciality;
        }
        else
        {
            SpecialityBox.Text = "";
        }
    }

    private void Save_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(FnameBox.Text) ||
                string.IsNullOrWhiteSpace(NameBox.Text) ||
                BirthPicker.SelectedDate == null ||
                GroupBox.SelectedItem == null)
            {
                return;
            }

            Group group = (Group)GroupBox.SelectedItem!;

            User user = new User
            {
                Fname = FnameBox.Text,
                Name = NameBox.Text,
                Patronumic = PatronumicBox.Text,
                DateBirth = DateOnly.FromDateTime(BirthPicker.SelectedDate.Value.Date),
                IdGroup = group.IdGroup
            };

            ConnectionClass.connect.Users.Add(user);
            ConnectionClass.connect.SaveChanges();

            Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"AddStudentWindow.Save_Click error: {ex}");
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
            Console.WriteLine($"AddStudentWindow.Close_Click error: {ex}");
            throw;
        }
    }

    internal async Task ShowDialog()
    {
        throw new NotImplementedException();
    }
}
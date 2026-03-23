using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.EntityFrameworkCore;
using StudentsAvalonia.Classes;
using StudentsAvalonia.Data;
using System;
using System.Linq;

namespace StudentsAvalonia.Pages;

public partial class RegistPage : Window
{
    public RegistPage()
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
        try
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
        catch (Exception ex)
        {
            Console.WriteLine($"RegistPage.GroupBox_SelectionChanged error: {ex}");
            throw;
        }
    }

    private void Reg_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            Console.WriteLine("RegistPage.Reg_Click start");

            if (string.IsNullOrWhiteSpace(FnameBox.Text) ||
                string.IsNullOrWhiteSpace(NameBox.Text) ||
                string.IsNullOrWhiteSpace(LoginBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Text) ||
                BirthPicker.SelectedDate == null ||
                GroupBox.SelectedItem == null)
            {
                StatusText.Text = "Заполните все поля и выберите группу";
                return;
            }

            Login? sameLogin = ConnectionClass.connect.Logins
                .FirstOrDefault(x => x.LoginName == LoginBox.Text);

            if (sameLogin != null)
            {
                StatusText.Text = "Пользователь с таким логином уже существует";
                return;
            }

            Login login = new Login
            {
                LoginName = LoginBox.Text,
                Password = PasswordBox.Text
            };

            ConnectionClass.connect.Logins.Add(login);
            ConnectionClass.connect.SaveChanges();

            Group group = (Group)GroupBox.SelectedItem!;

            User user = new User
            {
                Fname = FnameBox.Text,
                Name = NameBox.Text,
                Patronumic = PatronumicBox.Text,
                DateBirth = DateOnly.FromDateTime(BirthPicker.SelectedDate.Value.Date),
                IdGroup = group.IdGroup,
                IdLogPass = login.IdLogins
            };

            ConnectionClass.connect.Users.Add(user);
            ConnectionClass.connect.SaveChanges();

            StatusText.Text = "Регистрация завершена. Возвращаемся на вход";
            new AuthPage().Show();
            Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"RegistPage.Reg_Click error: {ex}");
            StatusText.Text = "Ошибка при регистрации. Смотрите консоль.";
            throw;
        }
    }

    private void Back_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            new AuthPage().Show();
            Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"RegistPage.Back_Click error: {ex}");
            throw;
        }
    }
}
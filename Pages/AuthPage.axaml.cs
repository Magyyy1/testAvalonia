using Avalonia.Controls;
using Avalonia.Interactivity;
using StudentsAvalonia.Classes;
using System;
using System.Linq;

namespace StudentsAvalonia.Pages;

public partial class AuthPage : Window
{
    public AuthPage()
    {
        InitializeComponent();
    }

    private void Login_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            Console.WriteLine("AuthPage.Login_Click start");

            if (string.IsNullOrWhiteSpace(LoginBox.Text) || string.IsNullOrWhiteSpace(PasswordBox.Text))
            {
                StatusText.Text = "Введите логин и пароль";
                return;
            }

            var user = ConnectionClass.connect.Logins.FirstOrDefault(x =>
                x.LoginName == LoginBox.Text &&
                x.Password == PasswordBox.Text);

            if (user != null)
            {
                StatusText.Text = "Успешно. Открываем окно...";
                new HomePage().Show();
                Close();
                return;
            }

            StatusText.Text = "Ошибка: логин/пароль не найдены.";
            Console.WriteLine("AuthPage.Login_Click: invalid credentials");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"AuthPage.Login_Click error: {ex}");
            StatusText.Text = "Ошибка при входе: " + ex.Message;
            // не пробрасываем дальше, чтобы приложение не падало
        }
    }

    private void Reg_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            new RegistPage().Show();
            Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"AuthPage.Reg_Click error: {ex}");
            throw;
        }
    }
}
using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using StudentsAvalonia.Pages;

namespace StudentsAvalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);

        AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
        {
            Console.WriteLine("UnhandledException: " + e.ExceptionObject?.ToString());
        };

        TaskScheduler.UnobservedTaskException += (sender, e) =>
        {
            Console.WriteLine("UnobservedTaskException: " + e.Exception.ToString());
            e.SetObserved();
        };

        Avalonia.Threading.Dispatcher.UIThread.UnhandledException += (sender, e) =>
        {
            Console.WriteLine("UIThread.UnhandledException: " + e.Exception.ToString());
            e.Handled = true;
        };
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new AuthPage();
        }

        base.OnFrameworkInitializationCompleted();
    }
}
global using DatabaseAssignment.Contexts;
using DatabaseAssignment.MVVM.ViewModels;
using DatabaseAssignment.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace DatabaseAssignment;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IHost app { get; private set; }

    public App()
    {
        app = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<DbServices>();

        }).Build();
    }
    protected async override void OnStartup(StartupEventArgs e)
    {
        var _navigation = app.Services.GetRequiredService<NavigationStore>();
        var db = app.Services.GetRequiredService<DbServices>();

        app.Start();

        _navigation.CurrentViewModel = new HomeScreenViewModel(_navigation, db);
        var MainWindow = app.Services.GetRequiredService<MainWindow>();
        MainWindow.DataContext = new MainViewModel(_navigation, db);

        MainWindow.Show();
        base.OnStartup(e);
    }
}

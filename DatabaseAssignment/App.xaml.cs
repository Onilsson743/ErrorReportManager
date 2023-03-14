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

        }).Build();
    }
    protected async override void OnStartup(StartupEventArgs e)
    {
        var _navigation = app.Services.GetRequiredService<NavigationStore>();
        _navigation.CurrentViewModel = new HomeScreenViewModel(_navigation);
        DbServices db = new DbServices();
        await db.GetErrorReports();

        var MainWindow = app.Services.GetRequiredService<MainWindow>();
        MainWindow.DataContext = new MainViewModel(_navigation);

        MainWindow.Show();
        base.OnStartup(e);
    }
}

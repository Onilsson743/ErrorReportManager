global using DatabaseAssignment.Contexts;
using DatabaseAssignment.MVVM.ViewModels;
using DatabaseAssignment.Services;
using System.Windows;

namespace DatabaseAssignment;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected async override void OnStartup(StartupEventArgs e)
    {
        DbServices db = new DbServices();
        await db.GetErrorReports();
        await db.GetPersons();

        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel()
        };
        MainWindow.Show();
        base.OnStartup(e);
    }
}

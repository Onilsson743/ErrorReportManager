using CommunityToolkit.Mvvm.ComponentModel;
using DatabaseAssignment.MVVM.Models;
using DatabaseAssignment.Services;
using DatabaseAssignment.Services.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DatabaseAssignment.MVVM.ViewModels;

public partial class ErrorReportsViewModel : ObservableObject
{
    private DbServices db = new DbServices();
    private readonly NavigationStore _navigation;
    public static ObservableCollection<Comments> Comments { get; set; } = new ObservableCollection<Comments>();
    public ObservableCollection<ErrorReport> ErrorReportsList { get; }
    public ICommand GoToAdminViewCommand { get; }
    public ICommand RefreshCommand { get; }
    

    public ErrorReportsViewModel(NavigationStore navigation)
    {
        _navigation = navigation;
        GoToAdminViewCommand = new NavigateCommand<AdminViewModel>(_navigation, () => new AdminViewModel(_navigation));
        ErrorReportsList = ContentDataServices.GetList();
        RefreshCommand = Refresh();
    }
    public ICommand Refresh()
    {
        return new NavigateCommand<ErrorReportsViewModel>(_navigation, () => new ErrorReportsViewModel(_navigation));
    }
}

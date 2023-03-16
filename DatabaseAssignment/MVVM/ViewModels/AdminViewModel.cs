using CommunityToolkit.Mvvm.ComponentModel;
using DatabaseAssignment.Services.Helpers;
using DatabaseAssignment.Services;
using System.Windows.Input;

namespace DatabaseAssignment.MVVM.ViewModels;

public partial class AdminViewModel : ObservableObject
{
    private readonly NavigationStore _navigation;
    private readonly DbServices db;

    public ICommand GoToHomeViewCommand { get; }
    public ICommand GoToErrorReportsCommand { get; }
    public ICommand GoToSearchCommand { get; }

    public AdminViewModel(NavigationStore navigation, DbServices _db)
    {
        _navigation = navigation;
        db = _db;
        GoToHomeViewCommand = new NavigateCommand<HomeScreenViewModel>(_navigation, () => new HomeScreenViewModel(_navigation, db));
        GoToErrorReportsCommand = new NavigateCommand<ErrorReportsViewModel>(_navigation, () => new ErrorReportsViewModel(_navigation, db));
        GoToSearchCommand = new NavigateCommand<SearchErrorReportViewModel>(_navigation, () => new SearchErrorReportViewModel(_navigation, db));
    }

}

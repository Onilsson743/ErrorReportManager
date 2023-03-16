using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DatabaseAssignment.MVVM.Models;
using DatabaseAssignment.Services;
using DatabaseAssignment.Services.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DatabaseAssignment.MVVM.ViewModels;

public partial class ErrorReportsViewModel : ObservableObject
{
    private readonly DbServices db;
    private readonly NavigationStore _navigation;
    [ObservableProperty]
    public ObservableCollection<Comments> comments;

    [ObservableProperty]
    public ObservableCollection<ErrorReport> errorReports;

    [ObservableProperty]
    public ErrorReport report;
    public ICommand GoToAdminViewCommand { get; }
    public ICommand ShowDetailsCommand { get; }


    public ErrorReportsViewModel(NavigationStore navigation, DbServices _db)
    {
        _navigation = navigation;
        db = _db;
        GoToAdminViewCommand = new NavigateCommand<AdminViewModel>(_navigation, () => new AdminViewModel(_navigation, db));
        ShowDetailsCommand = GoToDetails();
        GetReportsAsync();
        Comments = ContentDataServices.Comments;
    }

    public async Task GetReportsAsync()
    {
        ErrorReports = await db.GetErrorReports();
    }

    public ICommand GoToDetails()
    {
        return new NavigateCommand<SearchErrorReportViewModel>(_navigation, () => new SearchErrorReportViewModel(_navigation, db));
    }


}

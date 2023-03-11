using CommunityToolkit.Mvvm.ComponentModel;
using DatabaseAssignment.MVVM.Models;
using DatabaseAssignment.Services;
using DatabaseAssignment.Services.Helpers;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DatabaseAssignment.MVVM.ViewModels;

public partial class ErrorReportsViewModel : ObservableObject
{
    private readonly NavigationStore _navigation;
    public ObservableCollection<ErrorReport> ErrorReportsList { get; }
    public ObservableCollection<Comments> CommentList { get; }

    public ICommand GoToAdminViewCommand { get; }
    

    public ErrorReportsViewModel(NavigationStore navigation)
    {
        _navigation = navigation;
        GoToAdminViewCommand = new NavigateCommand<AdminViewModel>(_navigation, () => new AdminViewModel(_navigation));
        CommentList = ContentDataServices.Comments;
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using DatabaseAssignment.MVVM.Models;
using DatabaseAssignment.Services.Helpers;
using DatabaseAssignment.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DatabaseAssignment.MVVM.ViewModels;

partial class SearchErrorReportViewModel : ObservableObject
{
    private DbServices db = new DbServices();
    private readonly NavigationStore _navigation;
    public static ObservableCollection<Comments> Comments { get; set; } = new ObservableCollection<Comments>();
    public static ErrorReport ErrorReport { get; set; } = new ErrorReport();

    public ICommand GoToAdminViewCommand { get; }


    public SearchErrorReportViewModel(NavigationStore navigation)
    {
        _navigation = navigation;
        GoToAdminViewCommand = new NavigateCommand<AdminViewModel>(_navigation, () => new AdminViewModel(_navigation));
    }

}

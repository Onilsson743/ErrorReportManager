using CommunityToolkit.Mvvm.ComponentModel;
using DatabaseAssignment.Services.Helpers;
using DatabaseAssignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DatabaseAssignment.MVVM.ViewModels;

public partial class AdminViewModel : ObservableObject
{
    private readonly NavigationStore _navigation;

    public ICommand GoToHomeViewCommand { get; }
    public ICommand GoToErrorReportsCommand { get; }
    public ICommand GoToSearchCommand { get; }

    public AdminViewModel(NavigationStore navigation)
    {
        _navigation = navigation;
        GoToHomeViewCommand = new NavigateCommand<HomeScreenViewModel>(_navigation, () => new HomeScreenViewModel(_navigation));
        GoToErrorReportsCommand = new NavigateCommand<ErrorReportsViewModel>(_navigation, () => new ErrorReportsViewModel(_navigation));
        //GoToSearchCommand = new NavigateCommand<SearchErrorReportViewModel>(_navigation, () => new SearchErrorReportViewModel(_navigation));
    }
}

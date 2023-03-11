using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DatabaseAssignment.MVVM.Models;
using DatabaseAssignment.Services;
using DatabaseAssignment.Services.Helpers;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DatabaseAssignment.MVVM.ViewModels;

partial class MainErrorReportsViewModel : ObservableObject
{

    private readonly NavigationStore _navigation;

    public ICommand ToMainMenu { get; }

    public MainErrorReportsViewModel(NavigationStore navigation)
    {
        _navigation = navigation;
        ToMainMenu = new NavigateCommand<MainViewModel>(_navigation, () => new MainViewModel(_navigation));

    }

    










    //[ObservableProperty]
    //private ObservableObject currentViewModel = new ActiveErrorReportsViewModel();

    //[RelayCommand]
    //public void ShowNewErrorReports() => CurrentViewModel = new NewErrorReportsViewModel();
    //[RelayCommand]
    //public void ShowActiveErrorReports() => CurrentViewModel = new ActiveErrorReportsViewModel();
    //[RelayCommand]
    //public void ShowFinishedErrorReports() => CurrentViewModel = new FinishedErrorReportsViewModel();
    //[RelayCommand]
    //public void ShowSearchErrorReports() => CurrentViewModel = new SearchErrorReportViewModel();

}

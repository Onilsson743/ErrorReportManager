using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DatabaseAssignment.MVVM.ViewModels;

partial class MainViewModel : ObservableObject
{

    [ObservableProperty]
    private ObservableObject currentViewModel = new AddErrorReportViewModel();

    
    [RelayCommand]
    public void GoToErrorReportsView() => CurrentViewModel = new MainErrorReportsViewModel();
    [RelayCommand]
    public void GoToAddErrorReportView() => CurrentViewModel = new AddErrorReportViewModel();

}

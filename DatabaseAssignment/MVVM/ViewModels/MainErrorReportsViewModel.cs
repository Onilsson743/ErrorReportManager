using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace DatabaseAssignment.MVVM.ViewModels;

partial class MainErrorReportsViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableObject currentViewModel = new ActiveErrorReportsViewModel();

    [RelayCommand]
    public void ShowNewErrorReports() => CurrentViewModel = new NewErrorReportsViewModel();
    [RelayCommand]
    public void ShowActiveErrorReports() => CurrentViewModel = new ActiveErrorReportsViewModel();
    [RelayCommand]
    public void ShowFinishedErrorReports() => CurrentViewModel = new FinishedErrorReportsViewModel();

}

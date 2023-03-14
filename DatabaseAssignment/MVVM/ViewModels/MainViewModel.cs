using CommunityToolkit.Mvvm.ComponentModel;
using DatabaseAssignment.Services;
using DatabaseAssignment.Services.Helpers;
using System.Windows.Input;

namespace DatabaseAssignment.MVVM.ViewModels;

partial class MainViewModel : ObservableObject
{
    private readonly NavigationStore _navigation;
    public ObservableObject CurrentViewModel => _navigation.CurrentViewModel;

    public ICommand ToManageCommand { get; }
    public ICommand ToAddErrorReportCommand { get; }

    public MainViewModel(NavigationStore navigation)
    {
        _navigation = navigation;

        _navigation.CurrentViewModelChanged += OnCurrentViewModelChanged;
        ToManageCommand = new NavigateCommand<AdminViewModel>(_navigation, () => new AdminViewModel(_navigation));
        ToAddErrorReportCommand = new NavigateCommand<AddErrorReportViewModel>(_navigation, () => new AddErrorReportViewModel(_navigation));

    }

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}




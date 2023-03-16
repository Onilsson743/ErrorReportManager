using CommunityToolkit.Mvvm.ComponentModel;
using DatabaseAssignment.Services;
using DatabaseAssignment.Services.Helpers;
using System.Windows.Input;

namespace DatabaseAssignment.MVVM.ViewModels;

partial class MainViewModel : ObservableObject
{
    private readonly NavigationStore _navigation;
    private readonly DbServices db;
    public ObservableObject CurrentViewModel => _navigation.CurrentViewModel;

    public ICommand ToManageCommand { get; }
    public ICommand ToAddErrorReportCommand { get; }

    public MainViewModel(NavigationStore navigation, DbServices _db)
    {
        _navigation = navigation;
        db = _db;
        _navigation.CurrentViewModelChanged += OnCurrentViewModelChanged;
        ToManageCommand = new NavigateCommand<AdminViewModel>(_navigation, () => new AdminViewModel(_navigation, db));
        ToAddErrorReportCommand = new NavigateCommand<AddErrorReportViewModel>(_navigation, () => new AddErrorReportViewModel(_navigation, db));

    }

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}




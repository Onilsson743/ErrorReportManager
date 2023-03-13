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

//    [ObservableProperty]
//    private ObservableObject currentViewModel = new AddErrorReportViewModel();

//    [RelayCommand]
//    public void GoToErrorReportsView() => CurrentViewModel = new MainErrorReportsViewModel();
//    [RelayCommand]
//    public void GoToAddErrorReportView() => CurrentViewModel = new AddErrorReportViewModel();


//    public class ChangeViewModelMessage
//    {
//        public object NewViewModel { get; }
//        public ChangeViewModelMessage(object newViewModel)
//        {
//            NewViewModel = newViewModel;
//        }
//    }

//    public MainViewModel()
//    {
//        // Register to receive ChangeViewModelMessage messages
//        Messenger.Default.Register<ChangeViewModelMessage>(this, message =>
//        {
//            CurrentViewModel = (ObservableObject)message.NewViewModel;
//        });

//        CurrentViewModel = new AddErrorReportViewModel();
//    }
}




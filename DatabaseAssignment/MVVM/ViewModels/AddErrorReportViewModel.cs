using CommunityToolkit.Mvvm.ComponentModel;
using DatabaseAssignment.Services;
using DatabaseAssignment.Services.Helpers;
using System.Windows.Input;


namespace DatabaseAssignment.MVVM.ViewModels;

public partial class AddErrorReportViewModel : ObservableObject
{

    private readonly NavigationStore _navigation;

    public ICommand GoToHomeViewCommand { get; }


    public AddErrorReportViewModel(NavigationStore navigation)
    {
        _navigation = navigation;
        GoToHomeViewCommand = new NavigateCommand<HomeScreenViewModel>(_navigation, () => new HomeScreenViewModel(_navigation));
        //UpdateCommand = Update();
    }

    //private ICommand Update()
    //{
    //    return new NavigateCommand<ContactsViewModel>(_AdressBook, () => new ContactsViewModel(_AdressBook));
    //}







    //[RelayCommand]
    //public void ToIssues()
    //{
    //    Messenger.Default.Send(new ChangeViewModelMessage(new MainErrorReportsViewModel()));
    //}

}

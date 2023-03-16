using CommunityToolkit.Mvvm.ComponentModel;
using DatabaseAssignment.Services;
using DatabaseAssignment.Services.Helpers;
using System.Windows.Input;


namespace DatabaseAssignment.MVVM.ViewModels;

public partial class AddErrorReportViewModel : ObservableObject
{

    private readonly NavigationStore _navigation;
    private readonly DbServices db;

    public ICommand GoToHomeViewCommand { get; }


    public AddErrorReportViewModel(NavigationStore navigation, DbServices _db)
    {
        db = _db;
        _navigation = navigation;
        GoToHomeViewCommand = new NavigateCommand<HomeScreenViewModel>(_navigation, () => new HomeScreenViewModel(_navigation, db));
    }

}

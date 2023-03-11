using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAssignment.Services.Helpers;

public class NavigateCommand<T> : BaseCommand where T : ObservableObject
{
    private readonly NavigationStore _AdressBook;
    private readonly Func<T> _createViewModel;

    public NavigateCommand(NavigationStore _navigation, Func<T> createViewModel)
    {
        _AdressBook = _navigation;
        _createViewModel = createViewModel;
    }

    public override void Execute(object? parameter)
    {
        _AdressBook.CurrentViewModel = _createViewModel();
    }
}

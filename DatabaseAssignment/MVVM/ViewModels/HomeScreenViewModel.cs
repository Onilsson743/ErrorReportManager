using CommunityToolkit.Mvvm.ComponentModel;
using DatabaseAssignment.Services;
using DatabaseAssignment.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DatabaseAssignment.MVVM.ViewModels
{
    public partial class HomeScreenViewModel : ObservableObject
    {
        private readonly NavigationStore _navigation;

        public ICommand GoToAddViewCommand { get; }
        public ICommand GoToAdminViewCommand { get; }

        public HomeScreenViewModel(NavigationStore navigation)
        {
            _navigation = navigation;
            GoToAddViewCommand = new NavigateCommand<AddErrorReportViewModel>(_navigation, () => new AddErrorReportViewModel(_navigation));
            GoToAdminViewCommand = new NavigateCommand<AdminViewModel>(_navigation, () => new AdminViewModel(_navigation));
        }
    }
}

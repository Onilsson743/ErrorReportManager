using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DatabaseAssignment.MVVM.Models;
using DatabaseAssignment.Services;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using static DatabaseAssignment.MVVM.ViewModels.MainViewModel;

namespace DatabaseAssignment.MVVM.ViewModels;

public partial class FinishedErrorReportsViewModel : ObservableObject
{

    
    public static ObservableCollection<ErrorReport> FinishedErrorReports = new ObservableCollection<ErrorReport>();


    public static ObservableCollection<Comments> Comments { get; set; } = new ObservableCollection<Comments>();


    //private ObservableCollection<ErrorReport> test;

    //public ObservableCollection<ErrorReport> Test
    //{
    //    get { return test; }
    //    set { SetProperty(ref test, value); }
    //}


    //public static void setFinishedErrorReports(ObservableCollection<ErrorReport> reports)
    //{
    //    Test = reports;
    //}

    //public event PropertyChangedEventHandler PropertyChanged;

    //private ObservableCollection<ErrorReport> _errorReports;
    //public ObservableCollection<ErrorReport> ErrorReports
    //{
    //    get { return _errorReports; }
    //    set
    //    {
    //        _errorReports = value;
    //        OnPropertyChanged(nameof(ErrorReports));
    //    }
    //}

    //public FinishedErrorReportsViewModel()
    //{
    //    ErrorReports = new ObservableCollection<ErrorReport>();
    //}

    //private void OnPropertyChanged(string propertyName)
    //{
    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //}




    //[RelayCommand]
    //public void ToAddError()
    //{
    //    Messenger.Default.Send(new ChangeViewModelMessage(new AddErrorReportViewModel()));
    //}
}

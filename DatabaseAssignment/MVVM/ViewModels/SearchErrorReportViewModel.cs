using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DatabaseAssignment.MVVM.Models;
using DatabaseAssignment.MVVM.Models.Entities;
using DatabaseAssignment.Services;
using DatabaseAssignment.Services.Helpers;
using System;
using System.Windows;
using System.Windows.Input;

namespace DatabaseAssignment.MVVM.ViewModels;

public partial class SearchErrorReportViewModel : ObservableObject
{
    private readonly NavigationStore _navigation;
    private readonly DbServices db;

    [ObservableProperty]
    public static ErrorReport report;

    [ObservableProperty]
    public string input;

    
    //public static ErrorReport ErrorReport { get; set; } = new ErrorReport();
    public ICommand GoToAdminViewCommand { get; }


    public SearchErrorReportViewModel(NavigationStore navigation, DbServices _db)
    {
        db = _db;
        _navigation = navigation;
        GoToAdminViewCommand = new NavigateCommand<AdminViewModel>(_navigation, () => new AdminViewModel(_navigation, db));
        Report = ContentDataServices.ErrorReport;
    }

    [RelayCommand]
    public async void GetReport()
    {
        var id = Int32.Parse(Input);
        var report = await db.GetOneErrorReport(id);
        if (report != null)
        {
            Report = report;
        }
        else
        {
            MessageBox.Show("Inget ärende med det ID nummret hittades.", "Varning");
        }
    }
    [RelayCommand]
    public async void Remove()
    {
        MessageBoxResult result = MessageBox.Show($"Är du säker på att du vill ta bort det här ärendet? \n \nId: {Report.ErrorId}", "Radera Ärende", MessageBoxButton.YesNo);

        if (MessageBoxResult.Yes == result)
        {
            await db.RemoveErrorReport(Report.ErrorId);
            MessageBox.Show("Kontakted Raderad!");
            Report = null;
        }
    }

    [ObservableProperty]
    public string commentinput;

    [RelayCommand]
    private async void AddComment()
    {
        if (Report != null)
        {
            var comment = new CommentsEntity
            {
                Comment = Commentinput,
                ErrorReportId = Report.ErrorId
            };
            await db.AddCommentToErrorReport(comment);
            var response = await db.GetOneErrorReport(Report.ErrorId);
            if (response != null)
            {
                Report = response;
            }

            MessageBox.Show("Din kommentar har lagts till!", "Info");
        } else
        {
            MessageBox.Show("Vänligen sök efter ett ärende först för att lägga till kommentarer", "Varning!");
        }

    }

}

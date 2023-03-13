using DatabaseAssignment.MVVM.Models.Entities;
using DatabaseAssignment.MVVM.Models;
using DatabaseAssignment.MVVM.Views.CustomWindow;
using DatabaseAssignment.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DatabaseAssignment.MVVM.ViewModels;

namespace DatabaseAssignment.MVVM.Views;

/// <summary>
/// Interaction logic for ErrorReportsView.xaml
/// </summary>
public partial class ErrorReportsView : UserControl
{
    public ErrorReportsView()
    {
        InitializeComponent();
    }
    DbServices db = new DbServices();
    public ErrorReport errorReport { get; set; } = new ErrorReport();
    private void Border_ShowComments(object sender, MouseButtonEventArgs e)
    {
        var button = (Border)sender;
        var contact = (ErrorReport)button.DataContext;
        errorReport = contact;
        ErrorReportsViewModel.Comments.Clear();
        foreach (var comment in contact.CommentsList)
        {
            ErrorReportsViewModel.Comments.Add(comment);
        }
    }

    private async void btn_AddCommentClick(object sender, RoutedEventArgs e)
    {

        if (errorReport.ErrorId != 0)
        {
            var comment = new CommentsEntity
            {
                Comment = tb_Comment.Text,
                ErrorReportId = errorReport.ErrorId
            };
            await db.AddCommentToErrorReport(comment);
            await db.GetErrorReports();
            tb_Comment.Text = string.Empty;
            MessageBox.Show("Din kommentar har lagts till!", "Info");
        }
        else
        {
            MessageBox.Show("Vänligen välj ett ärende från listan till vänster för att lägga till en kommentar", "Varning!");
        }
    }

    private void btn_CommentMouseUp(object sender, MouseButtonEventArgs e)
    {
        Border_ShowComments(errorReport, e);
    }

    private void btn_ShowDetails(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var report = (ErrorReport)button.DataContext;

        MoreDetailsWindow window = new MoreDetailsWindow(report);
        window.Show();
    }

    private async void btn_Remove(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var report = (ErrorReport)button.DataContext;

        MessageBoxResult result = MessageBox.Show($"Är du säker på att du vill ta bort det här ärendet? \n \nId: {report.ErrorId}", "Radera Ärende", MessageBoxButton.YesNo);

        if (MessageBoxResult.Yes == result)
        {
            await db.RemoveErrorReport(report.ErrorId);
            MessageBox.Show("Kontakted Raderad!");
        }        
    }
}

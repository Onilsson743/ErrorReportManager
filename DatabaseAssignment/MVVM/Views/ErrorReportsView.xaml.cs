using DatabaseAssignment.MVVM.Models.Entities;
using DatabaseAssignment.MVVM.Models;
using DatabaseAssignment.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        ContentDataServices.Comments.Clear();
        foreach (var comment in contact.CommentsList)
        {
            ContentDataServices.Comments.Add(comment);
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

    private void btn_SetErrorReport(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var report = (ErrorReport)button.DataContext;

        ContentDataServices.ErrorReport = report;
    }
}

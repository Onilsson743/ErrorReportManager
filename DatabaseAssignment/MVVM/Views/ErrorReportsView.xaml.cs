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
    public ErrorReport ErrorReport { get; set; } = new ErrorReport();
    private void Border_ShowComments(object sender, MouseButtonEventArgs e)
    {
        var button = (Border)sender;
        var contact = (ErrorReport)button.DataContext;
        ErrorReport = contact;
        ContentDataServices.Comments.Clear();
        foreach (var comment in contact.CommentsList)
        {
            ContentDataServices.Comments.Add(comment);
        }
    }

    private async void btn_AddCommentClick(object sender, RoutedEventArgs e)
    {

        if (ErrorReport.ErrorId != 0)
        {
            var comment = new CommentsEntity
            {
                Comment = tb_Comment.Text,
                ErrorReportId = ErrorReport.ErrorId
            };
            await db.AddCommentToErrorReport(comment);
            tb_Comment.Text = string.Empty;

            var report = await db.GetOneErrorReport(ErrorReport.ErrorId);
            ContentDataServices.Comments.Clear();
            foreach (var x in report.CommentsList)
            {
                ContentDataServices.Comments.Add(x);
            }
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

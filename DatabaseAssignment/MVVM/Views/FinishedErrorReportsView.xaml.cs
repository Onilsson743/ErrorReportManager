using DatabaseAssignment.MVVM.Models.Entities;
using DatabaseAssignment.MVVM.Models;
using DatabaseAssignment.MVVM.ViewModels;
using DatabaseAssignment.MVVM.Views.CustomWindow;
using DatabaseAssignment.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DatabaseAssignment.MVVM.Views
{
    /// <summary>
    /// Interaction logic for FinishedErrorReportsView.xaml
    /// </summary>
    public partial class FinishedErrorReportsView : UserControl
    {
        public ErrorReport errorReport { get; set; } = new ErrorReport();
        public FinishedErrorReportsView()
        {
            InitializeComponent();
            
        }
        
        private void Border_ShowComments(object sender, MouseButtonEventArgs e)
        {
            var button = (Border)sender;
            var contact = (ErrorReport)button.DataContext;
            errorReport = contact;
            FinishedErrorReportsViewModel.Comments.Clear();
            foreach (var comment in contact.CommentsList)
            {
                FinishedErrorReportsViewModel.Comments.Add(comment);
            }
        }

        private async void btn_AddCommentClick(object sender, RoutedEventArgs e)
        {

            if (errorReport.ErrorId != 0)
            {
                DbServices db = new DbServices();
                var comment = new CommentsEntity
                {
                    Comment = tb_Comment.Text,
                    ErrorReportId = errorReport.ErrorId
                };
                await db.AddCommentToErrorReport(comment);
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
    }
}


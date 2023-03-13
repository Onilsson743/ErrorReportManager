using DatabaseAssignment.MVVM.Models.Entities;
using DatabaseAssignment.MVVM.Models;
using DatabaseAssignment.MVVM.Views.CustomWindow;
using DatabaseAssignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DatabaseAssignment.MVVM.ViewModels;

namespace DatabaseAssignment.MVVM.Views
{
    /// <summary>
    /// Interaction logic for SearchErrorReportView.xaml
    /// </summary>
    public partial class SearchErrorReportView : UserControl
    {
        public SearchErrorReportView()
        {
            InitializeComponent();
        }
        DbServices db = new DbServices();
        public ErrorReport errorReport { get; set; } = new ErrorReport();
        private async void btn_AddCommentClick(object sender, RoutedEventArgs e)
        {
            var report = SearchErrorReportViewModel.ErrorReport;
            if (report.ErrorId != 0)
            {
                var comment = new CommentsEntity
                {
                    Comment = tb_Comment.Text,
                    ErrorReportId = report.ErrorId
                };
                await db.AddCommentToErrorReport(comment);
                MessageBox.Show("Din kommentar har lagts till!", "Info");
            }
            else
            {
                MessageBox.Show("Vänligen välj ett ärende från listan till vänster för att lägga till en kommentar", "Varning!");
            }
        }

        private void btn_ShowDetails(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var report = (ErrorReport)button.DataContext;

            MoreDetailsWindow window = new MoreDetailsWindow(report);
            window.Show();
        }

        private async void btn_Search(object sender, RoutedEventArgs e)
        {
            int id = Int32.Parse(tb_Search.Text);
            await db.GetOneErrorReport(id);
        }

        private void Border_ShowComments(object sender, MouseButtonEventArgs e)
        {
            var button = (Border)sender;
            var contact = (ErrorReport)button.DataContext;
            errorReport = contact;
            SearchErrorReportViewModel.Comments.Clear();
            foreach (var comment in contact.CommentsList)
            {
                SearchErrorReportViewModel.Comments.Add(comment);
            }
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

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
        private async void btn_UpdateStatus(object sender, RoutedEventArgs e)
        {
            DbServices db = new DbServices();
            var response = await db.UpdateErrorReportStatus(errorReport.ErrorId, cb_Status.Text);
            tb_Response.Text = response.Item1;
            tb_Status.Text = response.Item2;
        }
    }
}

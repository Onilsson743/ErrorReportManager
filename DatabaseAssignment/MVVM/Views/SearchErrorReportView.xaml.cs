using DatabaseAssignment.MVVM.Models.Entities;
using DatabaseAssignment.MVVM.Models;
using DatabaseAssignment.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        public ErrorReport errorReport { get; set; } = ContentDataServices.ErrorReport;
        private async void btn_AddCommentClick(object sender, RoutedEventArgs e)
        {
            var report = ContentDataServices.ErrorReport;
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

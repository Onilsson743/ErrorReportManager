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

        private async void btn_AddCommentClick(object sender, RoutedEventArgs e)
        {
            var report = SearchErrorReportViewModel.errorReport;
            if (report.ErrorId != 0)
            {
                DbServices db = new DbServices();
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
            //int id = Int32.Parse(tb_Search.Text);
            //DbServices db = new DbServices();
            //await db.GetOneErrorReport(id);
        }
    }
}

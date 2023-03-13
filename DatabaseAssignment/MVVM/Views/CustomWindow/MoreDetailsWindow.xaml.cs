using CommunityToolkit.Mvvm.ComponentModel;
using DatabaseAssignment.MVVM.Models;
using DatabaseAssignment.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace DatabaseAssignment.MVVM.Views.CustomWindow
{
    /// <summary>
    /// Interaction logic for MoreDetailsWindow.xaml
    /// </summary>
    public partial class MoreDetailsWindow : Window
    {
        private ErrorReport errorReport { get; set; } = new ErrorReport();
        public MoreDetailsWindow(ErrorReport report)
        {
            errorReport = report;
            DataContext = report;
            InitializeComponent();
        }

        private void btn_Close_Window(object sender, RoutedEventArgs e)
        {
            this.Close();
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

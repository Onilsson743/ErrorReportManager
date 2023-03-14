using DatabaseAssignment.MVVM.ViewModels;
using DatabaseAssignment.Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DatabaseAssignment.MVVM.Views
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : UserControl
    {
        public AdminView()
        {
            InitializeComponent();
        }
        DbServices db = new DbServices();

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //int id = Int32.Parse(tb_SearchId.Text);
            //var result = await db.GetOneErrorReport(id);
            //if (result != null)
            //{
            //    //SearchErrorReportViewModel.ErrorReport = result;
            //}
        }
    }
}

using DatabaseAssignment.MVVM.Models;
using DatabaseAssignment.MVVM.ViewModels;
using DatabaseAssignment.MVVM.Views.CustomWindow;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatabaseAssignment.MVVM.Views
{
    /// <summary>
    /// Interaction logic for NewErrorReportsView.xaml
    /// </summary>
    public partial class NewErrorReportsView : UserControl
    {
        public NewErrorReportsView()
        {
            InitializeComponent();
        }
        private void Border_ShowComments(object sender, MouseButtonEventArgs e)
        {
            var button = (Border)sender;
            var contact = (ErrorReport)button.DataContext;
            NewErrorReportsViewModel.Comments.Clear();
            foreach (var comment in contact.CommentsList)
            {
                NewErrorReportsViewModel.Comments.Add(comment);
            }     
        }

        private void btn_AddCommentClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var report = (ErrorReport)button.DataContext;

            if (report != null) 
            {
                MessageBox.Show("Finns något!", "Finns");
            } else
            {
                MessageBox.Show("Finns Inget!", "Finns inget");
            }

            //var button = (Button)sender;
            //var contact = (ErrorReport)button.DataContext;
            //NewErrorReportsViewModel.Comments.Clear();
            //foreach (var comment in contact.CommentsList)
            //{
            //    NewErrorReportsViewModel.Comments.Add(comment);
            //}


            //AddCommentsWindow window = new AddCommentsWindow();
            //window.Show();
        }
    }
}

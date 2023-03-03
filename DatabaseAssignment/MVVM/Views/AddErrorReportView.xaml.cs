using DatabaseAssignment.MVVM.Models;
using DatabaseAssignment.MVVM.Models.Entities;
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

namespace DatabaseAssignment.MVVM.Views
{
    /// <summary>
    /// Interaction logic for AddErrorReportView.xaml
    /// </summary>
    public partial class AddErrorReportView : UserControl
    {
        public AddErrorReportView()
        {
            InitializeComponent();
        }

        private async void AddErrorReportClick(object sender, RoutedEventArgs e)
        {
            var context = new PersonService();

            await context.Create(new PersonEntity
            {
                FirstName = tb_FirstName.Text,
                LastName = tb_LastName.Text,
                Email= tb_Email.Text,
                Phone = tb_PhoneNumber.Text
            });
            MessageBox.Show("klar", "klar");
        }
    }
}

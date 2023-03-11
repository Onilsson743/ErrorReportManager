using DatabaseAssignment.MVVM.Models.Entities;
using DatabaseAssignment.Services;
using System.Windows;
using System.Windows.Controls;


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
            var context = new DbServices();
            PersonEntity person = new PersonEntity
            {
                FirstName = tb_FirstName.Text,
                LastName = tb_LastName.Text,
                Email = tb_Email.Text,
                Phone = tb_PhoneNumber.Text,
            };
            AdressEntity adress = new AdressEntity
            {
                ApartmentNumber = tb_ApartmentNumber.Text,
                StreetName = tb_StreetName.Text,
                PostalCode = tb_PostalCode.Text,
                City= tb_City.Text
            };           
            string description = tb_Description.Text;

            await context.CreateErrorReport(person, adress, description);
            MessageBox.Show("klar", "klar");
        }
    }
}

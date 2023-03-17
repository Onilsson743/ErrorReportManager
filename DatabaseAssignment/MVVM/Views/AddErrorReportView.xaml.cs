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
        private readonly DbServices db = new DbServices();

        private async void AddErrorReportClick(object sender, RoutedEventArgs e)
        {
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

            await db.CreateErrorReport(person, adress, description);
            MessageBox.Show("Ärendet har lagts till!", "Info");


            //Clears all fields
            tb_FirstName.Text = string.Empty;
            tb_LastName.Text = string.Empty;
            tb_Email.Text = string.Empty;
            tb_PhoneNumber.Text = string.Empty;
            tb_ApartmentNumber.Text = string.Empty;
            tb_StreetName.Text = string.Empty;
            tb_PostalCode.Text = string.Empty;
            tb_City.Text = string.Empty;
            tb_Description.Text = string.Empty;

        }
    }
}

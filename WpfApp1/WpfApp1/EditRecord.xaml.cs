using System.Data;
using System.Windows;

namespace WpfApp1
{
    public partial class EditRecord : Window
    {
        private DataRowView _drv;

        public EditRecord(DataRowView drv)
        {
            InitializeComponent();

            _drv = drv;
            InitializeView();
        }

        public void InitializeView()
        {
            if (_drv.DataView.Table.ToString() == "employee")
            {
                EmployeeGrid.Visibility = Visibility.Visible;
                EmployeeFirstNameTextBox.Text = _drv["firstname"].ToString();
                EmployeeLastNameTextBox.Text = _drv["lastname"].ToString();
                EmployeeIRSNumberTextBox.Text = _drv["irs_number"].ToString();
                EmployeeDriverLicenceTextBox.Text = _drv["DriverLicense"].ToString();
                EmployeeSocialSecurityNumberTextBox.Text = _drv["SocialSecurityNumber"].ToString();
                EmployeeStreetTextBox.Text = _drv["street"].ToString();
                EmployeeNumberTextBox.Text = _drv["streetnumber"].ToString();
                EmployeePostalCodeTextBox.Text = _drv["postalcode"].ToString();
                EmployeeCityTextBox.Text = _drv["city"].ToString();
            }
            else if (_drv.DataView.Table.ToString() == "store")
            {
                StoreGrid.Visibility = Visibility.Visible;
                StoreIDTextBox.Text = _drv["storeid"].ToString();
                StoreStreetTextBox.Text = _drv["street"].ToString();
                StoreStreetNumberTextBox.Text = _drv["streetnumber"].ToString();
                StorePostalCodeTextBox.Text = _drv["postalcode"].ToString();
                StoreCityTextBox.Text = _drv["city"].ToString();
            }
            else if (_drv.DataView.Table.ToString() == "")
            {

            }
            else
            {

            }
           
        }

        private void Update_OnClick(object sender, RoutedEventArgs e)
        {
            if (_drv.DataView.Table.ToString() == "Employee")
            {

                App.RunCommand("update employee set firstname='" + EmployeeFirstNameTextBox.Text + "' where employee.irs_number=" + int.Parse(EmployeeIRSNumberTextBox.Text) + ";");
                App.RunCommand("update employee set lastname='" + EmployeeLastNameTextBox.Text + "' where employee.irs_number=" + int.Parse(EmployeeIRSNumberTextBox.Text) + ";");
                App.RunCommand("update employee set street='" + EmployeeStreetTextBox.Text + "' where employee.irs_number=" + int.Parse(EmployeeIRSNumberTextBox.Text) + ";");
                App.RunCommand("update employee set streetnumber='" + EmployeeNumberTextBox.Text + "' where employee.irs_number=" + int.Parse(EmployeeIRSNumberTextBox.Text) + ";");
                App.RunCommand("update employee set postalcode='" + EmployeePostalCodeTextBox.Text + "' where employee.irs_number=" + int.Parse(EmployeeIRSNumberTextBox.Text) + ";");
                App.RunCommand("update employee set city='" + EmployeeCityTextBox.Text + "' where employee.irs_number=" + int.Parse(EmployeeIRSNumberTextBox.Text) + ";");
                App.RunCommand("update employee set socialSecurityNumber='" + EmployeeSocialSecurityNumberTextBox.Text + "' where employee.irs_number=" + int.Parse(EmployeeIRSNumberTextBox.Text) + ";");
                App.RunCommand("update employee set driverlicense='" + EmployeeDriverLicenceTextBox.Text + "' where employee.irs_number=" + int.Parse(EmployeeIRSNumberTextBox.Text) + ";");

                App.RefreshDataGrid();
                MessageBox.Show("Employee updated succesfully!", "Success");
                Close();
            }
            else if (_drv.DataView.Table.ToString() == "store")
            {

                App.RunCommand("update store set street='" + StoreStreetTextBox.Text + "' where store.storeid=" + int.Parse(StoreIDTextBox.Text) + ";");
                App.RunCommand("update store set streetnumber='" + StoreStreetNumberTextBox.Text + "' where store.storeid=" + int.Parse(StoreIDTextBox.Text) + ";");
                App.RunCommand("update store set postalcode='" + StorePostalCodeTextBox.Text + "' where store.storeid=" + int.Parse(StoreIDTextBox.Text) + ";");
                App.RunCommand("update store set city='" + StoreCityTextBox.Text + "' where store.storeid=" + int.Parse(StoreIDTextBox.Text) + ";");

                App.RefreshDataGrid();
                MessageBox.Show("Store updated succesfully!", "Success");
                Close();
            }
        }
    }
}

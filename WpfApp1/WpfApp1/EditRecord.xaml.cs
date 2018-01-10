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
            if (_drv.DataView.Table.ToString() == "employee")
            {

                App.RunCommand("select * from employee where irs_number=" + int.Parse(EmployeeIRSNumberTextBox.Text));
                if (App.DataTable.Rows.Count != 0 && int.Parse(EmployeeIRSNumberTextBox.Text)!= int.Parse(_drv["irs_number"].ToString()))
                {
                    MessageBox.Show("Employee with IRS Number " + EmployeeIRSNumberTextBox.Text + " already exists!", "Error");
                    EmployeeIRSNumberTextBox.Text = "";
                    return;
                }
                App.RunCommand("update employee set firstname='" + EmployeeFirstNameTextBox.Text + "' where employee.irs_number=" + int.Parse(_drv["irs_number"].ToString()) + ";");
                App.RunCommand("update employee set lastname='" + EmployeeLastNameTextBox.Text + "' where employee.irs_number=" + int.Parse(_drv["irs_number"].ToString()) + ";");
                App.RunCommand("update employee set street='" + EmployeeStreetTextBox.Text + "' where employee.irs_number=" + int.Parse(_drv["irs_number"].ToString()) + ";");
                App.RunCommand("update employee set streetnumber='" + EmployeeNumberTextBox.Text + "' where employee.irs_number=" + int.Parse(_drv["irs_number"].ToString()) + ";");
                App.RunCommand("update employee set postalcode='" + EmployeePostalCodeTextBox.Text + "' where employee.irs_number=" + int.Parse(_drv["irs_number"].ToString()) + ";");
                App.RunCommand("update employee set city='" + EmployeeCityTextBox.Text + "' where employee.irs_number=" + int.Parse(_drv["irs_number"].ToString()) + ";");
                App.RunCommand("update employee set socialSecurityNumber='" + EmployeeSocialSecurityNumberTextBox.Text + "' where employee.irs_number=" + int.Parse(_drv["irs_number"].ToString()) + ";");
                App.RunCommand("update employee set driverlicense='" + EmployeeDriverLicenceTextBox.Text + "' where employee.irs_number=" + int.Parse(_drv["irs_number"].ToString()) + ";");
                App.RunCommand("update employee set irs_number='" + int.Parse(EmployeeIRSNumberTextBox.Text) + "' where employee.irs_number=" + int.Parse(_drv["irs_number"].ToString()) + ";");

                App.RefreshDataGrid();
                MessageBox.Show("Employee updated succesfully!", "Success");
                Close();
            }
            else if (_drv.DataView.Table.ToString() == "store")
            {
                App.RunCommand("select * from store where storeid=" + int.Parse(StoreIDTextBox.Text));
                if (App.DataTable.Rows.Count != 0 && int.Parse(StoreIDTextBox.Text) != int.Parse(_drv["Storeid"].ToString()))
                {
                    MessageBox.Show("Store with ID Number " + StoreIDTextBox.Text + " already exists!", "Error");
                    StoreIDTextBox.Text = "";
                    return;
                }
                App.RunCommand("update store set street='" + StoreStreetTextBox.Text + "' where store.storeid=" + int.Parse(_drv["storeid"].ToString()) + ";");
                App.RunCommand("update store set streetnumber='" + StoreStreetNumberTextBox.Text + "' where store.storeid=" + int.Parse(_drv["storeid"].ToString()) + ";");
                App.RunCommand("update store set postalcode='" + StorePostalCodeTextBox.Text + "' where store.storeid=" + int.Parse(_drv["storeid"].ToString()) + ";");
                App.RunCommand("update store set city='" + StoreCityTextBox.Text + "' where store.storeid=" + int.Parse(_drv["storeid"].ToString()) + ";");
                App.RunCommand("update store set storeid='" + int.Parse(StoreIDTextBox.Text) + "' where store.storeid=" + int.Parse(_drv["storeid"].ToString()) + ";");

                App.RefreshDataGrid();
                MessageBox.Show("Store updated succesfully!", "Success");
                Close();
            }
        }

        private void EmployeeIRSNumberTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(EmployeeIRSNumberTextBox.Text, out var n))
            {
                MessageBox.Show("IRS Number should be a numeric value.", "Error");
                EmployeeIRSNumberTextBox.Text = "";
                return;
            }
        }

        private void StoreIDTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(StoreIDTextBox.Text, out var n))
            {
                MessageBox.Show("Store ID Number should be a numeric value.", "Error");
                StoreIDTextBox.Text = "";
                return;
            }
        }
    }
}

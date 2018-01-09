using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class NewRecord : Window
    {
        public NewRecord()
        {
            InitializeComponent();

            InitializeComboBoxes();
        }

        public void InitializeComboBoxes()
        {
            RecordComboBox.Items.Add("Employee");
            RecordComboBox.Items.Add("Store");
            RecordComboBox.Items.Add("Vehicle");
            RecordComboBox.Items.Add("Customer");
            RecordComboBox.SelectedIndex = 0;

            for (var i = 1950; i <= DateTime.Now.Year; i++)
                YearMadeComboBox.Items.Add(i);
        }

        private void YearMadeCancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            YearMadeComboBox.SelectedIndex = -1;
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            if (Check()) return;

            if (RecordComboBox.SelectedItem.ToString() == "Employee")
            {
                App.RunCommand("select * from employee where irs_number=" + int.Parse(EmployeeIRSNumberTextBox.Text));
                if (App.DataTable.Rows.Count != 0)
                {
                    MessageBox.Show("Employee with IRS Number " + EmployeeIRSNumberTextBox.Text + " already exists!", "Error");
                    EmployeeIRSNumberTextBox.Text = "";
                    return;
                }

                try
                {
                    App.RunCommand("insert into employee (irs_number, lastname, firstname, driverlicense, socialsecuritynumber, street, streetnumber, postalcode, city)" +
                                   "values" +
                                   "(" + int.Parse(EmployeeIRSNumberTextBox.Text) + "," +
                                   "'" + EmployeeLastNameTextBox.Text + "'," +
                                   "'" + EmployeeFirstNameTextBox.Text + "'," +
                                   "'" + EmployeeDriverLicenceTextBox.Text + "'," +
                                   "'" + EmployeeSocialSecurityNumberTextBox.Text + "'," +
                                   "'" + EmployeeStreetTextBox.Text + "'," +
                                   "'" + EmployeeStreetNumberTextBox.Text + "'," +
                                   "'" + EmployeePostalCodeTextBox.Text + "'," +
                                   "'" + EmployeeCityTextBox.Text + "');");
                    App.RefreshDataGrid();
                    MessageBox.Show("Employee added succesfully!", "Success");
                    Close();
                }
                catch
                {
                    MessageBox.Show("Something went wrong!", "Error");
                }
            }
            else if (RecordComboBox.SelectedItem.ToString() == "Store")
            {
                App.RunCommand("select * from store where storeid=" + int.Parse(StoreIDTextBox.Text));
                if (App.DataTable.Rows.Count != 0)
                {
                    MessageBox.Show("Store with Store ID " + StoreIDTextBox.Text + " already exists!", "Error");
                    StoreIDTextBox.Text = "";
                    return;
                }

                try
                {
                    App.RunCommand("insert into store (storeid, street, streetnumber, postalcode, city)" +
                                   "values" +
                                   "(" + int.Parse(StoreIDTextBox.Text) + "," +
                                   "'" + StoreStreetTextBox.Text + "'," +
                                   "'" + StoreNumberTextBox.Text + "'," +
                                   "'" + StorePostalCodeTextBox.Text + "'," +
                                   "'" + StoreCityTextBox.Text + "');");
                    App.RefreshDataGrid();
                    MessageBox.Show("Store added succesfully!", "Success");
                    Close();
                }
                catch
                {
                    MessageBox.Show("Something went wrong!", "Error");
                }
            }
            else if (RecordComboBox.SelectedItem.ToString() == "Vehicle")
            {
                App.RunCommand("select * from vehicle where licenseplate ='" + (LicensePlateTextBox.Text) + "';");
                if (App.DataTable.Rows.Count != 0)
                {
                    MessageBox.Show("Vehicle with Licence Plate " + LicensePlateTextBox.Text + " already exists!", "Error");
                    LicensePlateTextBox.Text = "";
                    return;
                }

                try
                {
                    string yearmade, Nservice, Lservice, Insurance;
                    if (YearMadeComboBox.SelectedIndex != -1)
                        yearmade = "'" + YearMadeComboBox.SelectedItem.ToString() + "'";
                    else
                        yearmade = "null";

                    if (string.IsNullOrWhiteSpace(NextServiceTextBox.Text))
                        Nservice = "null";
                    else
                        Nservice = "'" + NextServiceTextBox.Text + "'";
                    if (string.IsNullOrWhiteSpace(LastServiceTextBox.Text))
                        Lservice = "null";
                    else
                        Lservice = "'" + LastServiceTextBox.Text + "'";
                    if (string.IsNullOrWhiteSpace(InsuranceExpirationDateTextBox.Text))
                        Insurance = "null";
                    else
                        Insurance = "'" + InsuranceExpirationDateTextBox.Text + "'";

                    App.RunCommand("insert into vehicle(licenseplate, model, cartype, make, yearmade, damages, malfunctions, nextservice,lastservice, InsuranceExpirationDate ,storeid)" +
                                   "values" +
                                   "('" + LicensePlateTextBox.Text + "'," +
                                   "'" + ModelTextBox.Text + "'," +
                                   "'" + CarTypeTextBox.Text + "'," +
                                   "'" + MakeTextBox.Text + "'," +
                                   "" + yearmade + "," +
                                   "'" + DamagesTextBox.Text + "'," +
                                   "'" + MalfunctionsTextBox.Text + "'," +
                                   "" + Nservice + "," +
                                   "" + Lservice + "," +
                                   "" + Insurance + "," +
                                   "" + int.Parse(StoreIDVehicleTextBox.Text) + ");");
                    App.RefreshDataGrid();
                    MessageBox.Show("Vehicle added succesfully!", "Success");
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong!", "Error");
                }
            }
            else if (RecordComboBox.SelectedItem.ToString() == "Customer")
            {
                App.RunCommand("select * from customer where customerid=" + int.Parse(CustomerIDTextBox.Text));
                if (App.DataTable.Rows.Count != 0)
                {
                    MessageBox.Show("Customer with Customer ID " + CustomerIDTextBox.Text + " already exists!", "Error");
                    CustomerIDTextBox.Text = "";
                    return;
                }

                try
                {
                    string registration;
                    if (string.IsNullOrWhiteSpace(FirstRegistrationTextBox.Text))
                        registration = "null";
                    else
                        registration = "'" + FirstRegistrationTextBox.Text + "'";

                    App.RunCommand("insert into customer(Customerid, FirstRegistration, SocialSecutiryNumber, DriverLicense, Irs_number, firstname, lastname, street, streetnumber, postalcode, city)" +
                                   "values" +
                                   "(" + int.Parse(CustomerIDTextBox.Text) + "," +
                                   "" + registration + "," +
                                   "'" + CustomerSocialSecurityNumberTextBox.Text + "'," +
                                   "'" + CustomerDriverLicenceTextBox.Text + "'," +
                                   "'" + CustomerIRSNumberTextBox.Text + "'," +
                                   "'" + CustomerFirstNameTextBox.Text + "'," +
                                   "'" + CustomerLastNameTextBox.Text + "'," +
                                   "'" + CustomerStreetTextBox.Text + "'," +
                                   "'" + CustomerNumberTextBox.Text + "'," +
                                   "'" + CustomerPostalCodeTextBox.Text + "'," +
                                   "'" + CustomerCityTextBox.Text + "');");
                    App.RefreshDataGrid();
                    MessageBox.Show("Customer added succesfully!", "Success");
                    Close();
                }
                catch
                {
                    MessageBox.Show("Something went wrong!", "Error");
                }
            }
        }

        private void RecordComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RecordComboBox.SelectedItem.ToString() == "Employee")
            {
                Height = 550;
                EmployeesGrid.Visibility = Visibility.Visible;
                StoreGrid.Visibility = Visibility.Collapsed;
                VehicleGrid.Visibility = Visibility.Collapsed;
                CustomerGrid.Visibility = Visibility.Collapsed;
            }
            else if (RecordComboBox.SelectedItem.ToString() == "Store")
            {
                Height = 450;
                EmployeesGrid.Visibility = Visibility.Collapsed;
                StoreGrid.Visibility = Visibility.Visible;
                VehicleGrid.Visibility = Visibility.Collapsed;
                CustomerGrid.Visibility = Visibility.Collapsed;
            }
            else if (RecordComboBox.SelectedItem.ToString() == "Vehicle")
            {
                Height = 750;
                EmployeesGrid.Visibility = Visibility.Collapsed;
                StoreGrid.Visibility = Visibility.Collapsed;
                VehicleGrid.Visibility = Visibility.Visible;
                CustomerGrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                Height = 650;
                EmployeesGrid.Visibility = Visibility.Collapsed;
                StoreGrid.Visibility = Visibility.Collapsed;
                VehicleGrid.Visibility = Visibility.Collapsed;
                CustomerGrid.Visibility = Visibility.Visible;
            }
        }

        private void IRSNumberTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (EmployeeIRSNumberTextBox.Text == "")
                EmpAst0.Visibility = Visibility.Visible;
            else
            {
                if (!int.TryParse(EmployeeIRSNumberTextBox.Text, out var n))
                {
                    MessageBox.Show("IRS Number should be a numeric value.", "Error");
                    EmployeeIRSNumberTextBox.Text = "";
                    return;
                }
                EmpAst0.Visibility = Visibility.Collapsed;
            }
        }

        private void StoreIDTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (StoreIDTextBox.Text == "")
                StoreAst1.Visibility = Visibility.Visible;
            else
            {
                if (!int.TryParse(StoreIDTextBox.Text, out var n))
                {
                    MessageBox.Show("Store ID should be a numeric value.", "Error");
                    StoreIDTextBox.Text = "";
                    return;
                }
                StoreAst1.Visibility = Visibility.Collapsed;
            }
        }

        private void StoreIDVehicleTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (StoreIDVehicleTextBox.Text == "")
                VehicleAst1.Visibility = Visibility.Visible;
            else
            {
                if (!int.TryParse(StoreIDVehicleTextBox.Text, out var n))
                {
                    MessageBox.Show("Store ID should be a numeric value.", "Error");
                    StoreIDVehicleTextBox.Text = "";
                    return;
                }
                VehicleAst1.Visibility = Visibility.Collapsed;
            }
        }
        private void LicensePlateTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (LicensePlateTextBox.Text == "")
                VehicleAst0.Visibility = Visibility.Visible;
            else
                VehicleAst0.Visibility = Visibility.Collapsed;
        }


        private void FirstNameTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (EmployeeFirstNameTextBox.Text == "")
                EmpAst1.Visibility = Visibility.Visible;
            else
                EmpAst1.Visibility = Visibility.Collapsed;
        }

        private void LastNameTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (EmployeeLastNameTextBox.Text == "")
                EmpAst2.Visibility = Visibility.Visible;
            else
                EmpAst2.Visibility = Visibility.Collapsed;
        }

        private void DriverLicenceTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (EmployeeDriverLicenceTextBox.Text == "")
                EmpAst3.Visibility = Visibility.Visible;
            else
                EmpAst3.Visibility = Visibility.Collapsed;
        }

        private void CustomerIDTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (CustomerIDTextBox.Text == "")
                CustAst0.Visibility = Visibility.Visible;
            else
            {
                if (!int.TryParse(CustomerIDTextBox.Text, out var n))
                {
                    MessageBox.Show("Customer ID should be a numeric value.", "Error");
                    CustomerIDTextBox.Text = "";
                    return;
                }
                CustAst0.Visibility = Visibility.Collapsed;
            }
        }

        private void CustomerFirstNameTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (CustomerFirstNameTextBox.Text == "")
                CustAst1.Visibility = Visibility.Visible;
            else
                CustAst1.Visibility = Visibility.Collapsed;
        }
        private void CustomerLastNameTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (CustomerFirstNameTextBox.Text == "")
                CustAst2.Visibility = Visibility.Visible;
            else
                CustAst2.Visibility = Visibility.Collapsed;
        }

        public bool Check()
        {
            if (RecordComboBox.SelectedItem.ToString() == "Employee")
            {
                IRSNumberTextBox_OnLostFocus(null, null);

                return !(EmpAst0.Visibility == Visibility.Collapsed &&
                       EmpAst1.Visibility == Visibility.Collapsed &&
                       EmpAst2.Visibility == Visibility.Collapsed &&
                       EmpAst3.Visibility == Visibility.Collapsed);
            }
            if (RecordComboBox.SelectedItem.ToString() == "Store")
            {
                StoreIDTextBox_OnLostFocus(null, null);

                return StoreAst1.Visibility != Visibility.Collapsed;
            }
            if (RecordComboBox.SelectedItem.ToString() == "Vehicle")
            {
                StoreIDVehicleTextBox_OnLostFocus(null, null);
               
                return !(VehicleAst0.Visibility == Visibility.Collapsed &&
                        VehicleAst1.Visibility == Visibility.Collapsed);
            }

            if (RecordComboBox.SelectedItem.ToString() == "Customer")
            {
                CustomerIDTextBox_OnLostFocus(null, null);

                return !(CustAst1.Visibility == Visibility.Collapsed &&
                       CustAst2.Visibility == Visibility.Collapsed);
            }

            return !(EmpAst0.Visibility == Visibility.Collapsed &&
                   EmpAst1.Visibility == Visibility.Collapsed &&
                   EmpAst2.Visibility == Visibility.Collapsed &&
                   EmpAst3.Visibility == Visibility.Collapsed);
        }
        


    
        


        
    }
}

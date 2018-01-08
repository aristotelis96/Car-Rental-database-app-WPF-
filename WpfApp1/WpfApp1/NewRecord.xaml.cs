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
                App.RunCommand("select * from vehicle where licenseplate =" + int.Parse(LicensePlateTextBox.Text));
                if (App.DataTable.Rows.Count != 0)
                {
                    MessageBox.Show("Vehicle with Licence Plate " + LicensePlateTextBox.Text + " already exists!", "Error");
                    LicensePlateTextBox.Text = "";
                    return;
                }

                try
                {
                    DateTime? yearmade;
                    if (YearMadeComboBox.SelectedIndex != -1)
                        yearmade = new DateTime(int.Parse(YearMadeComboBox.SelectedItem.ToString()), 1, 1);
                    else
                        yearmade = null;

                    App.RunCommand("insert into vehicle(licenseplate, model, cartype, make, yearmade, damages, malfunctions, storeid)" +
                                   "values" +
                                   "('" + LicensePlateTextBox.Text + "'," +
                                   "'" + ModelTextBox.Text + "'," +
                                   "'" + CarTypeTextBox.Text + "'," +
                                   "'" + MakeTextBox.Text + "'," +
                                   "'" + yearmade?.ToString("yyyy-MM-dd")  + "'," +
                                   "'" + DamagesTextBox.Text + "'," +
                                   "'" + MalfunctionsTextBox.Text + "'," +
                                  // "'" + NextServiceTextBox.Text + "'," +
                                  // "'" + LastServiceTextBox.Text + "'," +
                                  // "'" + InsuranceExpirationDateTextBox.Text + "'," +*/
                                       + int.Parse(StoreIDVehicleTextBox.Text) + ");");
                    App.RefreshDataGrid();
                    MessageBox.Show("Vehicle added succesfully!", "Success");
                    Close();
                }
                catch (Exception ex)
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
                //CustomerGrid.Visibility = Visibility.Collapsed;
            }
            else if (RecordComboBox.SelectedItem.ToString() == "Store")
            {
                Height = 450;
                EmployeesGrid.Visibility = Visibility.Collapsed;
                StoreGrid.Visibility = Visibility.Visible;
                VehicleGrid.Visibility = Visibility.Collapsed;
                //CustomerGrid.Visibility = Visibility.Collapsed;
            }
            else if (RecordComboBox.SelectedItem.ToString() == "Vehicle")
            {
                Height = 750;
                EmployeesGrid.Visibility = Visibility.Collapsed;
                StoreGrid.Visibility = Visibility.Collapsed;
                VehicleGrid.Visibility = Visibility.Visible;
                //CustomerGrid.Visibility = Visibility.Visible;
            }
            else
            {
                Height = 850;
                EmployeesGrid.Visibility = Visibility.Collapsed;
                StoreGrid.Visibility = Visibility.Collapsed;
                VehicleGrid.Visibility = Visibility.Collapsed;
                //CustomerGrid.Visibility = Visibility.Visible;
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
               
                /* if (YearMadeTextBox.Text == "")
                     YearMadeTextBox = null;
                 else
                     YearMadeTextBox.Text = "'" + YearMadeTextBox.Text + "'";
                 if (NextServiceTextBox.Text == "")
                     NextServiceTextBox = null;
                 if (LastServiceTextBox.Text == "")
                     LastServiceTextBox = null;
                 if (InsuranceExpirationDateTextBox.Text == "")
                     InsuranceExpirationDateTextBox = null;*/
                return !(VehicleAst0.Visibility == Visibility.Collapsed &&
                        VehicleAst1.Visibility == Visibility.Collapsed);
            }

            return !(EmpAst0.Visibility == Visibility.Collapsed &&
                   EmpAst1.Visibility == Visibility.Collapsed &&
                   EmpAst2.Visibility == Visibility.Collapsed &&
                   EmpAst3.Visibility == Visibility.Collapsed);
        }

        private void ViewPhones_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void AddPhone_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void ViewEmails_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void AddEmail_OnClick(object sender, RoutedEventArgs e)
        {

        }
    
        


        
    }
}

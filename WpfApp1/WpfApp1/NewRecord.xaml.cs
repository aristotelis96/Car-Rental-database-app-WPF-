using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class NewRecord : Window
    {
        public NewRecord()
        {
            InitializeComponent();

            InitializeRecordComboBox();
        }

        public void InitializeRecordComboBox()
        {
            RecordComboBox.Items.Add("Employee");
            RecordComboBox.Items.Add("Store");
            RecordComboBox.Items.Add("Vehicle");
            RecordComboBox.Items.Add("Customer");
            RecordComboBox.SelectedIndex = 0;
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            if (Check()) return;

            if (RecordComboBox.SelectedItem.ToString() == "Employee")
            {
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
                try
                {
                    App.RunCommand("insert into store (StoreID, street, streetnumber, postalcode, city)" +
                                   "values" +
                                   "(" + int.Parse(StoreidTextBox.Text) + "," +
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
                try
                {
                    App.RunCommand("insert into vehicle(LicensePlate,Model,CarType,Make,YearMade,Kilometers,CylinderCapacity,Horsepower,Damages,Mulfunctions,NextService,LastService,InsuranceExpirationDate,Storeid)" +
                                   "values" +
                                   "('" + LicensePlateTextBox.Text + "'," +
                                   "'" + ModelTextBox.Text + "'," +
                                   "'" + CarTypeTextBox.Text + "'," +
                                   "'" + MakeTextBox.Text + "'," +
                                   "" + YearMadeTextBox.Text + "," +
                                   "" + int.Parse(KilometersTextBox.Text) + "," +
                                   "" + int.Parse(CylinderCapacityTextBox.Text) + "," +
                                   "" + int.Parse(HorsePowerTextBox.Text) + "," +
                                   "'" + DamagesTextBox.Text + "'," +
                                   "'" + MalfunctionsTextBox.Text + "'," +
                                   "'" + NextServiceTextBox.Text + "'," +
                                   "'" + InsuranceExpirationDateTextBox.Text + "'," +
                                   "" + int.Parse(StoreIDVehicleTextBox.Text) + ");");
                    App.RefreshDataGrid();
                    MessageBox.Show("Vehicle added succesfully!", "Success");
                    Close();
                }
                catch
                {
                    MessageBox.Show("Something went wrong!", "Error");
                }

            }
        }

        private void Add_OnClick_Phone(object sender, RoutedEventArgs e)
        {
            
        }

        private void Add_OnClick_Email(object sender, RoutedEventArgs e)
        {

        }

        private void RecordComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RecordComboBox.SelectedItem.ToString() == "Employee")
            {
                EmployeesGrid.Visibility = Visibility.Visible;
                StoreGrid.Visibility = Visibility.Collapsed;
                VehicleGrid.Visibility = Visibility.Collapsed;
                //CustomerGrid.Visibility = Visibility.Visible;
            }
            else if (RecordComboBox.SelectedItem.ToString() == "Store")
            {
                EmployeesGrid.Visibility = Visibility.Collapsed;
                StoreGrid.Visibility = Visibility.Visible;
                VehicleGrid.Visibility = Visibility.Collapsed;
                //CustomerGrid.Visibility = Visibility.Visible;
            }
            else if (RecordComboBox.SelectedItem.ToString() == "Vehicle")
            {
                EmployeesGrid.Visibility = Visibility.Collapsed;
                StoreGrid.Visibility = Visibility.Collapsed;
                VehicleGrid.Visibility = Visibility.Visible;
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
            if (StoreidTextBox.Text == "")
                StoreAst1.Visibility = Visibility.Visible;
            else
            {
                if (!int.TryParse(StoreidTextBox.Text, out var n))
                {
                    MessageBox.Show("Store ID should be a numeric value.", "Error");
                    StoreidTextBox.Text = "";
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

                return !(StoreAst1.Visibility == Visibility.Collapsed);
            }
            if (RecordComboBox.SelectedItem.ToString() == "Vehicle")
            {
                StoreIDVehicleTextBox_OnLostFocus(null, null);
                if (YearMadeTextBox.Text == "")
                    YearMadeTextBox = null;
                else
                    YearMadeTextBox.Text = "'" + YearMadeTextBox.Text + "'";
                if (NextServiceTextBox.Text == "")
                    NextServiceTextBox = null;
                if (LastServiceTextBox.Text == "")
                    LastServiceTextBox = null;
                if (InsuranceExpirationDateTextBox.Text == "")
                    InsuranceExpirationDateTextBox = null;
                return !(VehicleAst0.Visibility == Visibility.Collapsed &&
                       VehicleAst1.Visibility == Visibility.Collapsed);
            }

            return !(EmpAst0.Visibility == Visibility.Collapsed &&
                   EmpAst1.Visibility == Visibility.Collapsed &&
                   EmpAst2.Visibility == Visibility.Collapsed &&
                   EmpAst3.Visibility == Visibility.Collapsed);
        }
    }
}

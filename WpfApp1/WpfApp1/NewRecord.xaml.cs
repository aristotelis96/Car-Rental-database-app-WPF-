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
<<<<<<< HEAD
            if (Check()) return;


            if (RecordComboBox.SelectedItem.ToString() == "Employee")
            {
                try
                {
                    App.RunCommand("insert into employee (irs_number, lastname, firstname, driverlicense, socialsecutirynumber, street, streetnumber, postalcode, city)" +
                                   "values" +
                                   "(" + int.Parse(IRSNumberTextBox.Text) + "," +
                                   "'" + LastNameTextBox.Text + "'," +
                                   "'" + FirstNameTextBox.Text + "'," +
                                   "'" + DriverLicenceTextBox.Text + "'," +
                                   +int.Parse(SocialSecurityNumberTextBox.Text) + "," +
                                   "'" + StreetTextBox.Text + "'," +
                                   +int.Parse(StreetNumberTextBox.Text) + "," +
                                   +int.Parse(PostalCodeTextBox.Text) + "," +
                                   "'" + CityTextBox.Text + "');");
                    App.RefreshDataGrid();
                    MessageBox.Show("Employee added succesfully!", "Success");
                    Close();
                }
                catch
                {
                    MessageBox.Show("Something went wrong!", "Error");
                }

            }
=======
                
            App.RunCommand("INSERT INTO employee (IRS_number, firstname, lastname, driverlicense, socialsecuritynumber," +
                            "street,streetnumber,postalcode,city)" +
                           "values" +
                           "(" + int.Parse(IRSNumberTextBox.Text) + ", " +
                           "'" + FirstNameTextBox.Text + "'," +
                           "'" + LastNameTextBox.Text + "'," +
                           "'" + DriverLicenceTextBox.Text + "'," +
                           "'" + SocialSecurityNumberTextBox.Text + "'," +
                           "'" + StreetTextBox.Text + "'," +
                           "'" + NumberTextBox.Text + "'," +
                           "'" + PostalCodeTextBox.Text + "'," +
                           "'" + CityTextBox.Text + "');" );
       
            App.RunCommand("select * from employee");
            App.DataGrid.DataContext = App.DataTable;
            MessageBox.Show("Employee added succesfully!", "Success");
            Close();
>>>>>>> a8cb5a234446226bacb41922f8c7574fda726db7
        }

        private void RecordComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void IRSNumberTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (IRSNumberTextBox.Text == "")
                EmpAst0.Visibility = Visibility.Visible;
            else
            {
                if (!int.TryParse(IRSNumberTextBox.Text, out var n))
                {
                    MessageBox.Show("IRS Number should be a numeric value.", "Error");
                    IRSNumberTextBox.Text = "";
                    return;
                }
                EmpAst0.Visibility = Visibility.Collapsed;
            }
        }

        private void FirstNameTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (FirstNameTextBox.Text == "")
                EmpAst1.Visibility = Visibility.Visible;
            else
                EmpAst1.Visibility = Visibility.Collapsed;
        }

        private void LastNameTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (LastNameTextBox.Text == "")
                EmpAst2.Visibility = Visibility.Visible;
            else
                EmpAst2.Visibility = Visibility.Collapsed;
        }

        private void DriverLicenceTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (DriverLicenceTextBox.Text == "")
                EmpAst3.Visibility = Visibility.Visible;
            else
                EmpAst3.Visibility = Visibility.Collapsed;
        }

        private void SocialSecurityNumberTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(SocialSecurityNumberTextBox.Text, out var n))
            {
                MessageBox.Show("Social Security Number should be a numeric value.", "Error");
                SocialSecurityNumberTextBox.Text = "";
            }
        }

        private void StreetNumberTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(StreetNumberTextBox.Text, out var n))
            {
                MessageBox.Show("Street Number should be a numeric value.", "Error");
                StreetNumberTextBox.Text = "";
            }
                
        }

        private void PostalCodeTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(PostalCodeTextBox.Text, out var n))
            {
                MessageBox.Show("Postal Code should be a numeric value.", "Error");
                PostalCodeTextBox.Text = "";
            }
        }

        public bool Check()
        {
            if (RecordComboBox.SelectedItem.ToString() == "Employee")
            {
                IRSNumberTextBox_OnLostFocus(null, null);
                SocialSecurityNumberTextBox_OnLostFocus(null, null);
                StreetNumberTextBox_OnLostFocus(null, null);
                PostalCodeTextBox_OnLostFocus(null, null);

                return !(EmpAst0.Visibility == Visibility.Collapsed &&
                       EmpAst1.Visibility == Visibility.Collapsed &&
                       EmpAst2.Visibility == Visibility.Collapsed &&
                       EmpAst3.Visibility == Visibility.Collapsed);
            }
            if (RecordComboBox.SelectedItem.ToString() == "Store")
            {
                return !(EmpAst0.Visibility == Visibility.Collapsed &&
                       EmpAst1.Visibility == Visibility.Collapsed &&
                       EmpAst2.Visibility == Visibility.Collapsed &&
                       EmpAst3.Visibility == Visibility.Collapsed);
            }
            if (RecordComboBox.SelectedItem.ToString() == "Vehicle")
            {
                return !(EmpAst0.Visibility == Visibility.Collapsed &&
                       EmpAst1.Visibility == Visibility.Collapsed &&
                       EmpAst2.Visibility == Visibility.Collapsed &&
                       EmpAst3.Visibility == Visibility.Collapsed);
            }

            return !(EmpAst0.Visibility == Visibility.Collapsed &&
                   EmpAst1.Visibility == Visibility.Collapsed &&
                   EmpAst2.Visibility == Visibility.Collapsed &&
                   EmpAst3.Visibility == Visibility.Collapsed);
        }
    }
}

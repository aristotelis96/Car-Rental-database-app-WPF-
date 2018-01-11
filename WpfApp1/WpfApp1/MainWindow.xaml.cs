using System.Data;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualBasic;


namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitializeTablesComboBox();
            App.DataGrid = DataGrid;
            App.RefreshDataGrid();
        }
      
        public void InitializeTablesComboBox()
        {
            TablesComboBox.Items.Add("Employee");
            TablesComboBox.Items.Add("Store");
            TablesComboBox.Items.Add("Vehicle");
            TablesComboBox.Items.Add("Customer");
            TablesComboBox.SelectedIndex = 0;
        }

        private void TablesComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TablesComboBox.SelectedItem.ToString() == "Store")
            {
                ViewPhones.Visibility = Visibility.Visible;
                ViewEmails.Visibility = Visibility.Visible;
                ViewEmployees.Visibility = Visibility.Visible;
                Numberofcars.Visibility = Visibility.Visible;
            }
            else
            {
                ViewPhones.Visibility = Visibility.Collapsed;
                ViewEmails.Visibility = Visibility.Collapsed;
                ViewEmployees.Visibility = Visibility.Collapsed;
                Numberofcars.Visibility = Visibility.Collapsed;
            }
            if (TablesComboBox.SelectedItem.ToString() == "Vehicle")
            {
                Horsepower.Visibility = Visibility.Visible;
                FindVehicle.Visibility = Visibility.Visible;
            }
            else
            {
                Horsepower.Visibility = Visibility.Collapsed;
                FindVehicle.Visibility = Visibility.Collapsed;
            }

            App.LastSelect = "SELECT * FROM " + TablesComboBox.SelectedItem.ToString() + ";";
            App.DataGrid = DataGrid;
            App.RefreshDataGrid();
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            new NewRecord().Show();
        }
        
        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
                new EditRecord((DataRowView) DataGrid.SelectedItem).Show();
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
            {
                var drv = (DataRowView) DataGrid.SelectedItem;
                var table = drv.DataView.Table.ToString();

                if (table == "employee") // ToDo
                {
                    var record = int.Parse(drv["IRS_NUMBER"].ToString());
                    if (MessageBox.Show("Delete " + table + " with IRS Number " + record + "?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            App.RunCommand("DELETE FROM " + table + " WHERE IRS_NUMBER LIKE '" + record + "';");
                            MessageBox.Show("Employee deleted succesfully!", "Success");
                            App.LastSelect = "SELECT * FROM EMPLOYEE";
                            App.RefreshDataGrid();
                        }
                        catch
                        {
                            MessageBox.Show("Error deleting record", "Error");
                        }
                    }
                }
                else if (table == "store")
                {
                    var record = int.Parse(drv["storeid"].ToString());
                    if (MessageBox.Show("Delete " + table + " with Store ID " + record + "?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            App.RunCommand("DELETE FROM " + table + " WHERE storeid LIKE '" + record + "';");
                            MessageBox.Show("Store deleted succesfully!", "Success");
                            App.LastSelect = "SELECT * FROM store";
                            App.RefreshDataGrid();
                        }
                        catch
                        {
                            MessageBox.Show("Error deleting record", "Error");
                        }
                    }
                }
                else if (table == "vehicle")
                {
                    var record = drv["licenseplate"].ToString();
                    if (MessageBox.Show("Delete " + table + " with License Plate " + record + "?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            App.RunCommand("DELETE FROM " + table + " WHERE licenseplate LIKE '" + record + "';");
                            MessageBox.Show("Vehicle deleted succesfully!", "Success");
                            App.LastSelect = "SELECT * FROM vehicle";
                            App.RefreshDataGrid();
                        }
                        catch
                        {
                            MessageBox.Show("Error deleting record", "Error");
                        }
                    }
                }
                else
                {
                    var record = int.Parse(drv["customerid"].ToString());
                    if (MessageBox.Show("Delete " + table + " with ID " + record + "?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            App.RunCommand("DELETE FROM " + table + " WHERE customerid LIKE '" + record + "';");
                            MessageBox.Show("Customer deleted succesfully!", "Success");
                            App.LastSelect = "SELECT * FROM customer";
                            App.RefreshDataGrid();
                        }
                        catch
                        {
                            MessageBox.Show("Error deleting record", "Error");
                        }
                    }
                }
            }

        }

        private void ViewPhones_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
                new PhonesWindow((DataRowView)DataGrid.SelectedItem).Show();
        }
        private void Numberofcars_OnClick(object sender, RoutedEventArgs e)
        {
            new NumberOfCars().Show();
        }

        private void ViewEmployees_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
                new Works((DataRowView)DataGrid.SelectedItem).Show();
        }
        private void HorsePower_OnClick(object sender, RoutedEventArgs e)
        {
            new HorsePower().Show();
        }

        private void FindVehicle_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int response = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("Give minimum number of km", "Vehicle", "Ex: 500000", 5, 5));
                new Kilometers(response).Show();
            }
            catch
            {
                MessageBox.Show("ERROR");
                return;

            }
        }
    }

}

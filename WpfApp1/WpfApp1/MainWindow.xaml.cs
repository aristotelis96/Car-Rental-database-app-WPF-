using System.Data;
using System.Windows;
using System.Windows.Controls;

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
    }
}

using System;
using System.Configuration;
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

            // ΓΕΙΑ ΣΟΥ γιαννη

            InitializeTablesComboBox();
            App.DataGrid = DataGrid;
            App.RefreshDataGrid();
        }
      
        public void InitializeTablesComboBox()
        {
            TablesComboBox.Items.Add("Employees");
            TablesComboBox.Items.Add("Stores");
            TablesComboBox.Items.Add("Vehicles");
            TablesComboBox.Items.Add("Customers");
            TablesComboBox.SelectedIndex = 0;
        }

        private void TablesComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
                else if (table == "")
                {
                    
                }
                else if (table == "")
                {

                }
                else
                {
                    
                }
            }

        }
    }
}

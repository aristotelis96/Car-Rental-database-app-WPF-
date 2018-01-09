using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class Works : Window
    {
        private DataRowView _drv;

        public Works(DataRowView drv)
        {
            InitializeComponent();
            _drv = drv;

            App.LastSelect = "SELECT * FROM Works where storeid="+ _drv["storeid"].ToString() + ";";
            App.DataGrid = DataGrid;
            App.RefreshDataGrid();
        }


        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            new AddPhone(int.Parse(_drv["storeid"].ToString())).Show();
        }



        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
            {
                var test = (DataRowView)DataGrid.SelectedItem;
                var record = int.Parse(test["IRS_Number"].ToString());
                if (MessageBox.Show("Delete Employee with IRS number: " + record + "?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        App.RunCommand("DELETE FROM Works WHERE irs_number LIKE '" + record + "';");
                        MessageBox.Show("Employee deleted succesfully!", "Success");
                        App.LastSelect = "SELECT * FROM works where storeid=" + _drv["storeid"].ToString() + ";";
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

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
            App.LastSelect = "SELECT works.*, employee.lastname as 'Surname' FROM Works INNER join employee on employee.irs_number = works.irs_number where storeid="+ _drv["storeid"].ToString() + ";";
            App.DataGrid = DataGrid;
            App.RefreshDataGrid();
        }


        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            new AddWork(int.Parse(_drv["storeid"].ToString())).Show();
        }



        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
            {
                var test = (DataRowView)DataGrid.SelectedItem;
                var record = int.Parse(test["IRS_Number"].ToString());
                var date = DateTime.Parse(test["startDate"].ToString());
                if (MessageBox.Show("Delete Employee with IRS number: " + record + "?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        App.RunCommand("DELETE FROM Works WHERE irs_number LIKE '" + record + "' && startdate LIKE '" + date.ToString("yyyy-MM-dd") + "';");
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

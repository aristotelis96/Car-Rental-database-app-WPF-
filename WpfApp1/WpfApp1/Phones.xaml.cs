using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class PhonesWindow : Window
    {
        private DataRowView _drv;

        public PhonesWindow(DataRowView drv)
        {
            InitializeComponent();
            _drv = drv;

            App.LastSelect = "SELECT num as 'Numbers:' FROM phonenumber where storeid="+ _drv["storeid"].ToString() + ";";
            App.DataGrid = DataGrid;
            App.RefreshDataGrid();
        }


        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            
        }



        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
            {
                var test = (DataRowView)DataGrid.SelectedItem;
                var record = int.Parse(test["Numbers:"].ToString());
                if (MessageBox.Show("Delete number " + record + "?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        App.RunCommand("DELETE FROM phonenumber WHERE num LIKE '" + record + "';");
                        MessageBox.Show("Employee deleted succesfully!", "Success");
                        App.LastSelect = "SELECT num as 'Numbers:' FROM phonenumber where storeid=" + _drv["storeid"].ToString() + ";";
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

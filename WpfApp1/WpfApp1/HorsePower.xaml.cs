using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class HorsePower : Window
    {
        
        public HorsePower()
        {
            InitializeComponent();

            App.LastSelect = "SELECT * from horsepower;";
            App.DataGrid = DataGrid;
            App.RefreshDataGrid();
        }
    }
}

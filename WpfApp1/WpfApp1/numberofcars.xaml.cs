using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class NumberOfCars : Window
    {
        
        public NumberOfCars()
        {
            InitializeComponent();

            App.LastSelect = "SELECT * from numberofcars;";
            App.DataGrid = DataGrid;
            App.RefreshDataGrid();
        }
    }
}

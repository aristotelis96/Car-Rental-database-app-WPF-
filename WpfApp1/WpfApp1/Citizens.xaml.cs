using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class Citizens : Window
    {
        
        public Citizens()
        {
            InitializeComponent();
            App.LastSelect = "SELECT COUNT(irs_number) AS 'Population', city as 'City' FROM employee GROUP BY city;";
            App.DataGrid = DataGrid;
            App.RefreshDataGrid();
        }
    }
}

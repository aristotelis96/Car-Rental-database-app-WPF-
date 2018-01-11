using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class Kilometers : Window
    {
        
        public Kilometers(int km)
        {
            InitializeComponent();

            App.LastSelect = "SELECT * from vehicle group by Licenseplate having (kilometers<=" + km + ") ORDER BY kilometers ASC;";
            App.DataGrid = DataGrid;
            App.RefreshDataGrid();
        }
    }
}

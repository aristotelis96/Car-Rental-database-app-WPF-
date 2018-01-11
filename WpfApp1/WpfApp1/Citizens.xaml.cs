using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class Citizens : Window
    {
        
        public Citizens(int i)
        {
            InitializeComponent();
            App.LastSelect = "SELECT COUNT(irs_number) AS 'Population', city as 'City' FROM employee GROUP BY city HAVING (COUNT(IRS_NUMBER)>="+ i + ") ORDER BY (COUNT(IRS_NUMBER)) DESC;";
            App.DataGrid = DataGrid;
            App.RefreshDataGrid();
        }
    }
}

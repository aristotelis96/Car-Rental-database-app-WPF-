using System.Data;
using System.Windows;

namespace WpfApp1
{
    public partial class EditRecord : Window
    {
        private DataRowView _drv;

        public EditRecord(DataRowView drv)
        {
            InitializeComponent();

            _drv = drv;
            InitializeView();
        }

        public void InitializeView()
        {
            if (_drv.DataView.Table.ToString() == "employee")
            {
                EmployeeGrid.Visibility = Visibility.Visible;
                EmployeeFirstNameTextBox.Text = _drv["firstname"].ToString();
                EmployeeLastNameTextBox.Text = _drv["lastname"].ToString();
                EmployeeIRSNumberTextBox.Text = _drv["irs_number"].ToString();
            }
            else if (_drv.DataView.Table.ToString() == "")
            {
                
            }
            else if (_drv.DataView.Table.ToString() == "")
            {

            }
            else
            {

            }
           
        }

        private void Update_OnClick(object sender, RoutedEventArgs e)
        {
            App.RunCommand("update employee set firstname='" + EmployeeFirstNameTextBox.Text + "' where employee.irs_number=" + int.Parse(EmployeeIRSNumberTextBox.Text) + ";");
            App.RefreshDataGrid();
            MessageBox.Show("Employee updated succesfully!", "Success");
         Close();   
        }
    }
}

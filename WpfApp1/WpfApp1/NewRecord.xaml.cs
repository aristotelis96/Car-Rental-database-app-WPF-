using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class NewRecord : Window
    {
        public NewRecord()
        {
            InitializeComponent();

            InitializeRecordComboBox();
        }

        public void InitializeRecordComboBox()
        {
            RecordComboBox.Items.Add("Employee");
            RecordComboBox.Items.Add("Store");
            RecordComboBox.Items.Add("Vehicle");
            RecordComboBox.Items.Add("Customer");
            RecordComboBox.SelectedIndex = 0;
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
                
            App.RunCommand("INSERT INTO employee (IRS_number, firstname, lastname)" +
                           "values" +
                           "(" + int.Parse(IRSNumberTextBox.Text) + ", " + FirstNameTextBox.Text + ", " + LastNameTextBox.Text + ");");
            App.RunCommand("select * from employee");
            App.DataGrid.DataContext = App.DataTable;
            MessageBox.Show("Employee added succesfully!", "Success");
            Close();
        }

        private void RecordComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class AddWork : Window
    {
        private int _ID;
        public AddWork(int ID)
        {
            InitializeComponent();
            _ID = ID;

        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {

            if (Check()) return;

            App.RunCommand("select * from employee where irs_number=" + int.Parse(IRS_numberTextBox.Text) + ";");
            if (App.DataTable.Rows.Count == 0)
            {
                MessageBox.Show("This employee does not exist!", "Error");
                IRS_numberTextBox.Text = "";
                return;
            }            
                
            string Startdate,Finisdate;
            Startdate = "'" + StartDateTextBox.Text + "'";
            if (string.IsNullOrWhiteSpace(FinishDateTextBox.Text))
                Finisdate = "null";
            else
                Finisdate = "'" + FinishDateTextBox.Text + "'";

            App.RunCommand("select * from works where Irs_number='" + int.Parse(IRS_numberTextBox.Text) + "' && startdate=" + Startdate + " && storeid='" + _ID + "';");
            if (App.DataTable.Rows.Count != 0)
            {
                MessageBox.Show("This employee alread worked at that store at that specific date!", "Error");
                IRS_numberTextBox.Text = "";
                return;
            }

            try
            {
                App.RunCommand("Insert into works(storeID,startdate, finishdate, position, irs_number)" +
                "values" +
                "(" + _ID + "," +
                "" + Startdate + "," +
                "" + Finisdate + "," +
                "'" + PositionTextBox.Text + "'," +
                "" + int.Parse(IRS_numberTextBox.Text) + ");");

                App.RefreshDataGrid();
                MessageBox.Show("Employer added succesfully!", "Success");
                Close();
            }
            catch
            {
                MessageBox.Show("Something went wrong!", "Error");
            }
        }

        private void StartDateTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (StartDateTextBox.Text == "")
                EmpAst0.Visibility = Visibility.Visible;
            else
                EmpAst0.Visibility = Visibility.Collapsed;
        }

        private void IRSNumberTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (IRS_numberTextBox.Text == "")
                EmpAst1.Visibility = Visibility.Visible;
            else
            {
                if (!int.TryParse(IRS_numberTextBox.Text, out var n))
                {
                    MessageBox.Show("IRS Number should be a numeric value.", "Error");
                    IRS_numberTextBox.Text = "";
                    return;
                }
                EmpAst1.Visibility = Visibility.Collapsed;
            }
        }
        public bool Check()
        {
            IRSNumberTextBox_OnLostFocus(null, null);

            return !(EmpAst0.Visibility == Visibility.Collapsed &&
                   EmpAst1.Visibility == Visibility.Collapsed);

        }

    }
}

using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class AddPhone : Window
    {
        private int _ID;
        public AddPhone(int ID)
        {
            InitializeComponent();
            _ID = ID;

        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text))
            {
                MessageBox.Show("Number is empty!");
                return;
            }
                
            App.RunCommand("select * from phonenumber where num=" + int.Parse(PhoneNumberTextBox.Text));
            if (App.DataTable.Rows.Count != 0)
            {
                MessageBox.Show("This number already exists!", "Error");
                PhoneNumberTextBox.Text = "";
                return;
            }

            App.RunCommand("Insert into phonenumber(storeid,num)" +
                "values" +
                "(" + _ID + "," +
                "" + int.Parse(PhoneNumberTextBox.Text) + ");");
            App.RefreshDataGrid();
            MessageBox.Show("Phone number added succesfully!", "Success");
            Close();
        }

        private void NumberTextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(PhoneNumberTextBox.Text, out var n))
            {
                MessageBox.Show("Phone number must be a numeric value.", "Error");
                PhoneNumberTextBox.Text = "";
                return;
            }
            
        }
         
    }
}

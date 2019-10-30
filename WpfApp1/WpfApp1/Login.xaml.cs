using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.ConnectionsString = "SERVER=" + server.Text + ";DATABASE=" + database.Text + ";UID=" + username.Text + ";PASSWORD=" + password.Password + ";";
                App.Connection = new MySqlConnection(App.ConnectionsString);
                App.Connection.Open();
                App.Connection.Close();             
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
            new MainWindow().Show();
            Close();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                login.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
    }
}

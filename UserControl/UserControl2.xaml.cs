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
using System.Windows.Navigation;
using System.Windows.Shapes;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace WpfFramePasCore.UserControl
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class UserControl2
    {
        static string server = "localhost";
        static string database = "cookies";
        static string user = "root";
        static string password = "ABCD1234";
        //string port = "3306";
        static string connectionString = "server=" + server + ";" +
                                    "uid=" + user + ";" +
                                    "pwd=" + password + ";" +
                                     "database=" + database + ";";

        MySqlConnection conn = new MySqlConnection(connectionString);

        public UserControl2()
        {
            InitializeComponent();
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            MyViewModel3 model1 = new MyViewModel3();
            MyViewModel2 model2 = new MyViewModel2();
            
            model2.IsShown = false;
            model2.visibility = Visibility.Hidden;

            model1.IsShown = true;
            model1.visibility = Visibility.Visible;

            ViewModel viewModel = new ViewModel();
            viewModel.DataLoad(model1, model2);

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.DataContext = viewModel;
        }

        private void textChangedEventHandler(object sender, RoutedEventArgs e)
        {
            
            try
            {
                conn.Open();
                string command;
                if (name2Search.Text == null)
                    command = "Select Id,name,main_adress,tel,email from clients;";
               else
                    command = "Select Id,name,main_adress,tel,email from clients where name = '"+ name2Search.Text +"';";

                MySqlCommand cmd = new MySqlCommand(command, conn);

                DataSet ds = new DataSet("clients");
                DataTable customertable = new DataTable();

                customertable.Load(cmd.ExecuteReader());
                dataGridCustomers.DataContext = customertable;                

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }
    }
}

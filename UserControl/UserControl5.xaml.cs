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
    /// Interaction logic for UserControl5.xaml
    /// </summary>
    public partial class UserControl5
    {
        public UserControl5()
        {
            InitializeComponent();
        }

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

        private void displayStocks(object sender, TextChangedEventArgs e)
        {
            try
            {
                conn.Open();
                string command;
                command = "Select * from ingredient where name like '%" + item2Search.Text + "%';";

                MySqlCommand cmd = new MySqlCommand(command, conn);

                DataSet ds = new DataSet("clients");
                DataTable customertable = new DataTable();

                customertable.Load(cmd.ExecuteReader());
                dataGridStocks.DataContext = customertable;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();

        }
        private void displayDeliveries(object sender, TextChangedEventArgs e)
        {
            try
            {
                conn.Open();
                string command;
                command = "Select * from ingredient where name like '%" + item2Search.Text + "%';";

                MySqlCommand cmd = new MySqlCommand(command, conn);

                DataSet ds = new DataSet("clients");
                DataTable customertable = new DataTable();

                customertable.Load(cmd.ExecuteReader());
                dataGridStocks.DataContext = customertable;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();

        }
        private void GoToP1()
        {
            MyViewModel1 model1 = new MyViewModel1();
            MyViewModel5 model2 = new MyViewModel5();

            model2.IsShown = false;
            model2.visibility = Visibility.Hidden;

            model1.IsShown = true;
            model1.visibility = Visibility.Visible;

            ViewModel viewModel = new ViewModel();
            viewModel.DataLoad(model1, model2);

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.DataContext = viewModel;
        }

        

        private void Back_click(object sender, RoutedEventArgs e)
        {
            GoToP1();
        }
    }
}

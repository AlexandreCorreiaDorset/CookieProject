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
    /// Interaction logic for UserControl6.xaml
    /// </summary>
    public partial class UserControl6
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

        public UserControl6()
        {
            InitializeComponent();

            RefreshDb();
        }
        private void RefreshDb()
        {

            MessageBox.Show("Delivery registered");
            try
            {
                conn.Open();
                string command;
                command = "Select * from delivery ;";

                MySqlCommand cmd = new MySqlCommand(command, conn);

                DataSet ds = new DataSet("clients");
                DataTable customertable = new DataTable();

                customertable.Load(cmd.ExecuteReader());
                dataGridDelivery.DataContext = customertable;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }
    
        private void addDelivery(object sender, RoutedEventArgs e)
        {
            string cNumber = Number.Text;
            string cPrice = Price.Text;
            string cDate = $"{Year.Text}-{Month.Text}-{Day.Text}";

            try
            {
                conn.Open();

                string command = $"update delivery set numberof = {cNumber}," +
                             $"price = {cPrice}," +
                             $"delivery_date = '{cDate}'"+
                             "ORDER BY Id DESC LIMIT 1; ";

                var cmd = new MySqlCommand(command, conn);

                cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
            MessageBox.Show("Delivery Registered");
            RefreshDb();
        }
        private void GoToP5()
        {
            MyViewModel5 model1 = new MyViewModel5();
            MyViewModel6 model2 = new MyViewModel6();

            model2.IsShown = false;
            model2.visibility = Visibility.Hidden;

            model1.IsShown = true;
            model1.visibility = Visibility.Visible;

            ViewModel viewModel = new ViewModel();
            viewModel.DataLoad(model1, model2);

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.DataContext = viewModel;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            GoToP5();
        }
    }
}

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

namespace WpfFramePasCore.UserControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1
    {
        public UserControl1()
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
        private void GoToP2(object sender, RoutedEventArgs e)
        {
            string numberofVcookie = number_Vanilla_Cookie.Text;
            string numberOfDcookie = number_Choco_Cookie.Text;
            string numberofCcookie = number_classic.Text ;
            string numberOfLcookie = number_Lemon_Cookie.Text;

            try
            {
                conn.Open();

                string command = "insert into commands (delivery_date, vanilla_cookie_number, " +
                    "               double_chocolate_cookie_number, classic_cookie_number, lemon_cookie_number)" +
                                    " values ('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "',"
                                    + numberofVcookie+","+numberOfDcookie+","
                                    +numberofCcookie+","+numberOfLcookie+");";

                MySqlCommand cmd = new MySqlCommand(command, conn);
                cmd.ExecuteReader();                

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();

            MyViewModel1 model1 = new MyViewModel1();
            MyViewModel2 model2 = new MyViewModel2();

            model2.IsShown = true;
            model2.visibility = Visibility.Visible;

            model1.IsShown = false;
            model1.visibility = Visibility.Hidden;

            ViewModel viewModel = new ViewModel();
            viewModel.DataLoad(model1, model2);

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.DataContext = viewModel;
        }
        private void GoToP3(object sender, RoutedEventArgs e)
        {
            MyViewModel1 model1 = new MyViewModel1();
            MyViewModel3 model2 = new MyViewModel3();

            model2.IsShown = true;
            model2.visibility = Visibility.Visible;

            model1.IsShown = false;
            model1.visibility = Visibility.Hidden;

            ViewModel viewModel = new ViewModel();
            viewModel.DataLoad(model1, model2);

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.DataContext = viewModel;
        }

        private void GoToP5(object sender, RoutedEventArgs e)
        {
            MyViewModel1 model1 = new MyViewModel1();
            MyViewModel5 model2 = new MyViewModel5();

            model2.IsShown = true;
            model2.visibility = Visibility.Visible;

            model1.IsShown = false;
            model1.visibility = Visibility.Hidden;

            ViewModel viewModel = new ViewModel();
            viewModel.DataLoad(model1, model2);

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.DataContext = viewModel;
        }
    }
}

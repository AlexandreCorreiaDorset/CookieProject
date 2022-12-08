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
            RefreshDB();
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            GoToP1();
        }

        private void textChangedEventHandler(object sender, RoutedEventArgs e)
        {
            RefreshDB();            
        }
        private void RefreshDB()
        {
            try
            {
                conn.Open();
                string command;
                command = "Select Id,name,main_adress,tel,email from clients where name like '%" + name2Search.Text + "%';";

                MySqlCommand cmd = new MySqlCommand(command, conn);
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


        private void dataGridCustomers_SelectionChanged(object sender, EventArgs e)
        {
            synchClientCommand();

            GoToP1();
            MessageBox.Show("Command registered");

        }
        private void GoToP1()
        {
            MyViewModel1 model1 = new MyViewModel1();
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
        private void synchClientCommand()
        {
            try
            {
                conn.Open();
                string command;
                command = "Select Id,name,main_adress,tel,email from clients where name like '%" + name2Search.Text + "%';";

                MySqlCommand cmd = new MySqlCommand(command, conn);
                DataTable customertable = new DataTable();
                customertable.Load(cmd.ExecuteReader());
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (true) {

                var cellInfo = dataGridCustomers.SelectedCells[0];
                var idSelectedClient = (cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Text;

                cellInfo = dataGridCustomers.SelectedCells[2];
                var adressSelectedClient = (cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Text;

                try
                {
                    conn.Open();
                    string command;
                    command = " update commands set Id_client = " + idSelectedClient +
                        ", adress = '" + adressSelectedClient +
                        "' ORDER BY Id DESC LIMIT 1;";

                    MySqlCommand cmd = new MySqlCommand(command, conn);
                    cmd.ExecuteReader();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close(); 
            }
        }

        private void addNewCustomerClick(object sender, RoutedEventArgs e)
        {
            string cName = Name.Text;
            string cAdress = Adress.Text;
            string cTel = Tel.Text;
            string cEmail = Email.Text;

            try
            {
                conn.Open();

                string command = "insert into clients (name, main_adress,tel, email)" +
                                " values ('"+ cName + "','" + cAdress + "','"+ cTel + "','" + cEmail + "');";

                MySqlCommand cmd = new MySqlCommand(command, conn);
                cmd.ExecuteReader();
                conn.Close();

                conn.Open();

                command = "update commands set Id_client = (select Id from clients order by Id DESC LIMIT 1),"+
                             "adress = (select adress from clients order by Id DESC LIMIT 1)"+
                             "ORDER BY Id DESC LIMIT 1; ";

                cmd = new MySqlCommand(command, conn);
                cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
            GoToP1();
            MessageBox.Show("Command registered");

        }
    }
}

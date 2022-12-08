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
    /// Interaction logic for UserControl3.xaml
    /// </summary>
    public partial class UserControl3
    {
        static string server = "localhost";
        static string database = "cookies";
        static string user = "root";
        static string password = "ABCD1234";
        //string port = "3306";
        static string connectionString = $"server={server};" +
                                    $"uid={user};" +
                                    $"pwd={password};" +
                                     $"database={database};";

        MySqlConnection conn = new MySqlConnection(connectionString);
        public UserControl3()
        {
            InitializeComponent();
            RefreshDb();
        }

        private void textChangedEventHandler(object sender, TextChangedEventArgs e)
        {
            RefreshDb();

        }
        private void RefreshDb()
        {
            try
            {
                conn.Open();
                string command;
                command = "select commands.Id, clients.name, delivery_date, adress," +
                            "vanilla_cookie_number, double_chocolate_cookie_number," +
                            "classic_cookie_number, lemon_cookie_number from commands" +
                        $" inner join clients on clients.Id = commands.Id_client where clients.name like '%{name2Search.Text}%';";

                MySqlCommand cmd = new MySqlCommand(command, conn);

                DataTable customertable = new DataTable();

                customertable.Load(cmd.ExecuteReader());
                dataGridCommand.DataContext = customertable;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void GoToP1(object sender, RoutedEventArgs e)
        {
            MyViewModel1 model1 = new MyViewModel1();
            MyViewModel3 model2 = new MyViewModel3();

            model2.IsShown = false;
            model2.visibility = Visibility.Hidden;

            model1.IsShown = true;
            model1.visibility = Visibility.Visible;

            ViewModel viewModel = new ViewModel();
            viewModel.DataLoad(model1, model2);

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.DataContext = viewModel;
        }

        private void dataGridCommand_SelectionChanged(object sender, EventArgs e)
        {
            var cellInfo = dataGridCommand.SelectedCells[0];
            var idSelectedClient = (cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Text;

            try
            {
                conn.Open();
                string command;
                command = $" delete from delivery where Id = {idSelectedClient};";

                MySqlCommand cmd = new MySqlCommand(command, conn);
                cmd.ExecuteReader();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();

            MessageBox.Show("User deleted !");
            RefreshDb();
        }
    }
}

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
                command = $"Select * from ingredients where ingredient_name like '%{item2Search.Text}%'" +
                "union Select * from ingredients where found_rows() = 0 and ingredient_name like '%%';";

                MySqlCommand cmd = new MySqlCommand(command, conn);

                DataTable ingredientsTable = new DataTable();

                ingredientsTable.Load(cmd.ExecuteReader());
                dataGridStocks.DataContext = ingredientsTable;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();

        }
        private void displayDeliveries(object sender, EventArgs e)
        {
            try
            {
                var cellInfo = dataGridStocks.SelectedCells[1];
                var itemName = (cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Text;

                conn.Open();
                string command;

                command = "Select delivery.Id, ingredients.ingredient_name, delivery_date,numberof, price from delivery " +
                            $"inner join ingredients on ingredients.Id = delivery.product_id  where ingredients.ingredient_name = '{itemName}';";

                MySqlCommand cmd = new MySqlCommand(command, conn);

                DataTable deliveryTable = new DataTable();

                deliveryTable.Load(cmd.ExecuteReader());
                dataGridliv.DataContext = deliveryTable;

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

        private void GoToP6(object sender, RoutedEventArgs e)
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
    }
}
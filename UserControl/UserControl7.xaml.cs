﻿using System;
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
    /// Interaction logic for UserControl7.xaml
    /// </summary>
    public partial class UserControl7
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
        public UserControl7()
        {
            InitializeComponent();
            RefreshDb();
        }

        private void GoToP1(object sender, RoutedEventArgs e)
        {
            MyViewModel1 model1 = new MyViewModel1();
            MyViewModel7 model2 = new MyViewModel7();

            model2.IsShown = false;
            model2.visibility = Visibility.Hidden;

            model1.IsShown = true;
            model1.visibility = Visibility.Visible;

            ViewModel viewModel = new ViewModel();
            viewModel.DataLoad(model1, model2);

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.DataContext = viewModel;
        }
        

        private void textChangedEventHandler(object sender, TextChangedEventArgs e)
        {
            RefreshDb();

        }

        private void dataGridCustomers_SelectionChanged(object sender, EventArgs e)
        {
            var cellInfo = dataGridCustomers.SelectedCells[0];
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

        private void addNewStockClick(object sender, RoutedEventArgs e)
        {

        }
        private void RefreshDb()
        {
            try
            {
                conn.Open();
                string command;
                command = "select delivery.Id, ingredients.ingredient_name, delivery_date,numberof, price from delivery" +
                        $" inner join ingredients on ingredients.Id = delivery.product_id where ingredients.ingredient_name like '%{name2Search.Text}%';";

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

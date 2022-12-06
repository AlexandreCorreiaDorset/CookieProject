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

namespace WpfFramePasCore.UserControl
{
    /// <summary>
    /// Interaction logic for UserControlManegerPage.xaml
    /// </summary>
    public partial class UserControlManegerPage
    {
        public UserControlManegerPage()
        {
            InitializeComponent();
        }
        private void GoToP1(object sender, RoutedEventArgs e)
        {
            MyViewModel1 model1 = new MyViewModel1();
            MyViewModelManegerPage model2 = new MyViewModelManegerPage();

            model2.IsShown = false;
            model2.visibility = Visibility.Hidden;

            model1.IsShown = true;
            model1.visibility = Visibility.Visible;

            ViewModel viewModel = new ViewModel();
            viewModel.DataLoad(model1, model2);

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.DataContext = viewModel;
        }

        private void GoToP7(object sender, RoutedEventArgs e)
        {
            MyViewModelManegerPage model1 = new MyViewModelManegerPage();
            MyViewModel7 model2 = new MyViewModel7();

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
            MyViewModelManegerPage model1 = new MyViewModelManegerPage();
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

        private void GoToP4(object sender, RoutedEventArgs e)
        {
            MyViewModelManegerPage model1 = new MyViewModelManegerPage();
            MyViewModel4 model2 = new MyViewModel4();

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

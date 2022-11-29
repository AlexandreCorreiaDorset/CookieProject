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
    /// Interaction logic for UserControl3.xaml
    /// </summary>
    public partial class UserControl3
    {
        public UserControl3()
        {
            InitializeComponent();
        }
        private void Button_Click3(object sender, RoutedEventArgs e)
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
    }
}

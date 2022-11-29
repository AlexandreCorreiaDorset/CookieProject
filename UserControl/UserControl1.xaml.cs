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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;


namespace WpfFramePasCore.UserControl
{
    class ViewModel : NotifyObject
    {
        private object currentVM;
        public object CurrentVM
        {
            get
            {
                return currentVM;
            }
            set
            {
                currentVM = value;
                OnPropertyChanged("CurrentVM");
            }
        }

        MyViewModel1 myView1 = new MyViewModel1();

        MyViewModel2 myView2 = new MyViewModel2();

        public ViewModel()
        {
            currentVM = DataLoad(myView1, myView2);
        }

        public object DataLoad(MyViewModel1 _myView1, MyViewModel2 _myView2)
        {
            if (_myView1.IsShown == true && _myView1.visibility == Visibility.Visible) { currentVM = _myView1; }
            if (_myView2.IsShown == true && _myView2.visibility == Visibility.Visible) { currentVM = _myView2; }

            OnPropertyChanged("CurrentVM");
            return currentVM;
        }
        public object DataLoad(MyViewModel1 _myView1, MyViewModel3 _myView2)
        {
            if (_myView1.IsShown == true && _myView1.visibility == Visibility.Visible) { currentVM = _myView1; }
            if (_myView2.IsShown == true && _myView2.visibility == Visibility.Visible) { currentVM = _myView2; }

            OnPropertyChanged("CurrentVM");
            return currentVM;
        }
        public object DataLoad(MyViewModel3 _myView1, MyViewModel2 _myView2)
        {
            if (_myView1.IsShown == true && _myView1.visibility == Visibility.Visible) { currentVM = _myView1; }
            if (_myView2.IsShown == true && _myView2.visibility == Visibility.Visible) { currentVM = _myView2; }

            OnPropertyChanged("CurrentVM");
            return currentVM;
        }
        public object DataLoad(MyViewModel1 _myView1, MyViewModel4 _myView2)
        {
            if (_myView1.IsShown == true && _myView1.visibility == Visibility.Visible) { currentVM = _myView1; }
            if (_myView2.IsShown == true && _myView2.visibility == Visibility.Visible) { currentVM = _myView2; }

            OnPropertyChanged("CurrentVM");
            return currentVM;
        }
        public object DataLoad(MyViewModel1 _myView1, MyViewModel5 _myView2)
        {
            if (_myView1.IsShown == true && _myView1.visibility == Visibility.Visible) { currentVM = _myView1; }
            if (_myView2.IsShown == true && _myView2.visibility == Visibility.Visible) { currentVM = _myView2; }

            OnPropertyChanged("CurrentVM");
            return currentVM;
        }
        public object DataLoad(MyViewModel1 _myView1, MyViewModel6 _myView2)
        {
            if (_myView1.IsShown == true && _myView1.visibility == Visibility.Visible) { currentVM = _myView1; }
            if (_myView2.IsShown == true && _myView2.visibility == Visibility.Visible) { currentVM = _myView2; }

            OnPropertyChanged("CurrentVM");
            return currentVM;
        }
    }
}

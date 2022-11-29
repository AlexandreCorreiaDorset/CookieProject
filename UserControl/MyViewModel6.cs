using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;


namespace WpfFramePasCore.UserControl
{
    class MyViewModel6 : NotifyObject
    {
        public MyViewModel6()
        {
            IsShown = false;
            visibility = Visibility.Hidden;
        }

        private bool isShown;
        public bool IsShown
        {
            get
            {
                return isShown;
            }
            set
            {
                isShown = value;
                OnPropertyChanged("IsShown");
            }
        }
        private Visibility _visibility;
        public Visibility visibility
        {
            get
            {
                return _visibility;
            }
            set
            {
                _visibility = value;
                OnPropertyChanged("visibility");
            }
        }
    }
}

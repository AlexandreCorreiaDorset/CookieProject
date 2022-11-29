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
    class MyViewModel1 : NotifyObject
    {        
        public MyViewModel1()
        {
            IsShown = true;
            visibility = Visibility.Visible;
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

        private bool isShown = true;
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

        public string Info1 { get; set; }
    }
}

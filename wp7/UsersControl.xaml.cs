using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Epiworx.Wp7
{
    public partial class UsersControl : UserControl
    {
        public string Title
        {
            get { return "users"; }
        }

        public UsersControl()
        {
            InitializeComponent();
        }
    }
}

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
using Epiworx.Wp7.Models;

namespace Epiworx.Wp7.Controls
{
    public partial class ProfileControl : UserControl
    {
        private ProfileModel _model;
        public ProfileModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                this.OnModelChanged();
            }
        }

        private void OnModelChanged()
        {
            this.DataContext = this.Model;
        }

        public ProfileControl()
        {
            InitializeComponent();
        }
    }
}

using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Epiworx.Wp7.Models
{
    public class LogonEventArgs : EventArgs
    {
        public bool IsAuthenticated { get; internal set; }
        public string Token { get; internal set; }
    }
}

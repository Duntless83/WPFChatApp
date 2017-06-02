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

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text.ToString();
            var pubwrapper = new PubnubWrapper();

            pubwrapper.OnPresence += Pubwrapper__status;
            pubwrapper.OnMessage += Pubwrapper_OnMessage;
            pubwrapper.OnStatus += Pubwrapper_OnStatus;
            pubwrapper.Initialise(username);
        }

        private void Pubwrapper_OnStatus(object source, MyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Pubwrapper_OnMessage(object source, MyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Pubwrapper__status(object source, MyEventArgs e)
        {
            //var obj = e.GetInfo().ToString();
        }
    }
}

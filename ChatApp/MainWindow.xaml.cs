using ChatApp.DependencyInjection;
using ChatApp.Interface;
using StructureMap;
using System;
using System.Windows;

namespace ChatApp
{
    public partial class MainWindow : Window
    {
        private IChatController _controller;
        public MainWindow()
        {
            InitializeComponent();

            var registry = new Registry();
            registry.IncludeRegistry<DependencyRegistry>();
            var container = new Container(registry);
            _controller = container.GetInstance<IChatController>();


            _controller.LogInEvent += _controller_LogInEvent;
        }

        private void _controller_LogInEvent(object sender, Events.SuccessfulLogin e)
        {
            if (e.LoggedIn)
                MakeChatGridVisible();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text.ToString();
            _controller.Login(username);
        }

        private void MakeChatGridVisible()
        {
            grdChat.HandleInvokeRequired(tb => tb.Visibility = Visibility.Visible);
            txtMessage.HandleInvokeRequired(tb => tb.Visibility = Visibility.Visible);
            btnSend.HandleInvokeRequired(tb => tb.Visibility = Visibility.Visible);
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            _controller.SendMessage(txtMessage.Text);
        }
    }
}

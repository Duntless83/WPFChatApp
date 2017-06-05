using ChatApp.DependencyInjection;
using ChatApp.Events;
using ChatApp.Interface;
using StructureMap;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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
            _controller.MessageReceived += _controller_MessageReceived;
            _controller.PresenceReceived += _controller_PresenceReceived;
        }

        private void _controller_PresenceReceived(object sender, PresenceEventArgs e)
        {
            lstOnlineUsers.HandleInvokeRequired(tb => tb.Visibility = Visibility.Visible);
            lstOnlineUsers.HandleInvokeRequired(tb => tb.Items.Add(new ListBoxItem { Content= e.Uuid }));
            lblUsersOnline.HandleInvokeRequired(tb => tb.Visibility = Visibility.Visible);
        }

        private void _controller_MessageReceived(object sender, MessageEventArgs e)
        {
            grdChat.HandleInvokeRequired(tb => tb.Items.Add(new MessageEventArgs { Message = e.Message }));
        }

        private void _controller_LogInEvent(object sender, SuccessfulLogin e)
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
            txtMessage.Text = "";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _controller.UnsubscribeFromChannel();
        }
    }
}

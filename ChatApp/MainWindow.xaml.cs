using ChatApp.DependencyInjection;
using ChatApp.Interface;
using StructureMap;
using System;
using System.Windows;

namespace ChatApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text.ToString();

            var registry = new Registry();
            registry.IncludeRegistry<DependencyRegistry>();
            var container = new Container(registry);
            var controller = container.GetInstance<IChatController>();

            if(controller.Login(username))
            {
                grdChat.Visibility = Visibility.Visible;
            }
        }
    }
}

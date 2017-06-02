using System;
using ChatApp.Events;
using ChatApp.Interface;

namespace ChatApp
{
    class ChatController : IChatController
    {
        public event EventHandler<SuccessfulLogin> LogInEvent;
        private readonly IPubnubWrapper _wrapper;

        public ChatController(IPubnubWrapper wrapper)
        {
            _wrapper = wrapper;

            _wrapper.StatusReceived += _wrapper_StatusReceived;
            _wrapper.PresenceReceived += _wrapper_PresenceReceived;
            _wrapper.MessageReceived += _wrapper_MessageReceived;
        }

        public void Login(string username)
        {
            _wrapper.Initialise(username);
        }

        public void SendMessage(string txt)
        {
            _wrapper.PublishMessage(txt);
        }

        private void _wrapper_MessageReceived(object sender, Events.MessageEventArgs e)
        {

        }


        private void _wrapper_PresenceReceived(object sender, Events.PresenceEventArgs e)
        {
            
        }

        private void _wrapper_StatusReceived(object sender, Events.StatusEventArgs e)
        {
            if (e.StatusCode == 200)
            {
                LogInEvent?.Invoke(this, new SuccessfulLogin
                {
                    LoggedIn = true
                });
            }
        }
    }
}

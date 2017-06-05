using System;
using ChatApp.Events;
using ChatApp.Interface;

namespace ChatApp
{
    class ChatController : IChatController
    {
        public event EventHandler<SuccessfulLogin> LogInEvent; 
        public event EventHandler<MessageEventArgs> MessageReceived;
        public event EventHandler<PresenceEventArgs> PresenceReceived;

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

        public void UnsubscribeFromChannel()
        {
            _wrapper.Unsubscribe();
        }

        public void SendMessage(string txt)
        {
            _wrapper.PublishMessage(txt);
        }

        private void _wrapper_MessageReceived(object sender, Events.MessageEventArgs e)
        {
            MessageReceived?.Invoke(this, new MessageEventArgs
            {
                Channel = e.Channel,
                Message = e.Message,
                Subscription = e.Subscription,
                TimeToken = e.TimeToken,
                userMetadata = e.userMetadata
            });
        }


        private void _wrapper_PresenceReceived(object sender, Events.PresenceEventArgs e)
        {
            PresenceReceived?.Invoke(this, e);
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

        public void CheckHereNow(string channel)
        {
            _wrapper.CheckHereNow(channel);
        }
    }
}

using ChatApp.Events;
using System;

namespace ChatApp.Interface
{
    public interface IChatController
    {
        void Login(string username);
        void UnsubscribeFromChannel();
        event EventHandler<SuccessfulLogin> LogInEvent;
        event EventHandler<MessageEventArgs> MessageReceived;
        event EventHandler<PresenceEventArgs> PresenceReceived;
        void SendMessage(string txt);
        void CheckHereNow(string channel);
    }
}

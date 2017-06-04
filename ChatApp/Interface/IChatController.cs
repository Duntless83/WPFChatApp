using ChatApp.Events;
using System;

namespace ChatApp.Interface
{
    public interface IChatController
    {
        void Login(string username);
        event EventHandler<SuccessfulLogin> LogInEvent;
        event EventHandler<MessageEventArgs> MessageReceived;
        event EventHandler<PresenceEventArgs> PresenceReceived;
        void SendMessage(string txt);
    }
}

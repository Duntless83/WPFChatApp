using ChatApp.Events;
using System;

namespace ChatApp.Interface
{
    public interface IChatController
    {
        void Login(string username);
        event EventHandler<SuccessfulLogin> LogInEvent;
        void SendMessage(string txt);
    }
}

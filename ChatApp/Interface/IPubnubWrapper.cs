using ChatApp.Events;
using System;

namespace ChatApp.Interface
{
    public interface IPubnubWrapper
    {
        void Initialise(string username);
        void Unsubscribe();
        void PublishMessage(string text);
        event EventHandler<StatusEventArgs> StatusReceived;
        event EventHandler<PresenceEventArgs> PresenceReceived;
        event EventHandler<MessageEventArgs> MessageReceived;
    }
}

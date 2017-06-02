using System;

namespace ChatApp.Events
{
    public class MessageEventArgs : EventArgs
    {
        public string Channel { get; set; }
        public string Message { get; set; }
        public string Subscription { get; set; }
        public long TimeToken { get; set; }
        public object userMetadata { get; set; }
    }
}

using System;

namespace ChatApp
{
    public class MyEventArgs : EventArgs
    {
        private string EventInfo;
        public MyEventArgs(string text)
        {
            EventInfo = text;
        }
        public string GetInfo()
        {
            return EventInfo;
        }
    }
}

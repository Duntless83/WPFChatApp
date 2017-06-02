using System;
using System.Collections.Generic;

namespace ChatApp.Events
{
    public class PresenceEventArgs: EventArgs
    {
        public string Channel { get; set; }
        public string Event { get; set; }
        public string[] Join { get; set; }
        public string[] Leave { get; set; }
        public int Occupancy { get; set; }
        public Dictionary<string, object> State { get; set; }
        public string Subscription { get; set; }
        public string[] Timeout { get; set; }
        public long Timestamp { get; set; }
        public long TimeToken { get; set; }
        public object userMetadata { get; set; }
        public string Uuid { get; set; }
    }
}

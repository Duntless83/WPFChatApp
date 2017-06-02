using PubnubApi;
using System;
using System.Collections.Generic;

namespace ChatApp.Events
{
    public class StatusEventArgs :EventArgs
    {
        public string Uuid { get; set; }
        public int StatusCode { get; set; }
        public List<string> AffectedChannelGroups { get; set; }
        public List<string> AffectedChannels { get; set; }
        public string AuthKey { get; set; }
        public PNStatusCategory Category { get; set; }
        public object ClientRequest { get; set; }
        public bool Error { get; set; }
        public PNErrorData ErrorData { get; set; }
        public PNOperationType Operation { get; set; }
        public string Origin { get; set; }
        public bool TlsEnabled { get; set; }
    }
}

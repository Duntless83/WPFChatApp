using System;
using PubnubApi;

namespace ChatApp
{
    public delegate void MyEventHandler(object source, MyEventArgs e);
    public class PubnubListener : SubscribeCallback
    {
        public event MyEventHandler OnPresence;
        public event MyEventHandler OnStatus;
        public event MyEventHandler OnMessage;
        private Pubnub _pubnub;
        public PubnubListener(Pubnub pubnub)
        {
            _pubnub = pubnub;
        }
        public override void Message<T>(Pubnub pubnub, PNMessageResult<T> message)
        {
            OnMessage(this, new MyEventArgs(pubnub.JsonPluggableLibrary.SerializeToJsonString(message)));
        }

        public override void Presence(Pubnub pubnub, PNPresenceEventResult presence)
        {
            OnPresence(this, new MyEventArgs(pubnub.JsonPluggableLibrary.SerializeToJsonString(presence)));
        }
        public override void Status(Pubnub pubnub, PNStatus status)
        {
            OnStatus(this, new MyEventArgs(pubnub.JsonPluggableLibrary.SerializeToJsonString(status)));
        }
    }
}

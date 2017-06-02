using System;
using ChatApp.Events;
using ChatApp.Interface;
using PubnubApi;

namespace ChatApp
{
    public class PubnubWrapper : SubscribeCallback, IPubnubWrapper
    {
        private Pubnub _pubnub;

        public event EventHandler<StatusEventArgs> StatusReceived;
        public event EventHandler<PresenceEventArgs> PresenceReceived;
        public event EventHandler<MessageEventArgs> MessageReceived;

        public void Initialise(string username)
        {
            PNConfiguration config = new PNConfiguration();
            config.PublishKey = "pub-c-667861b4-2631-4779-9264-c94b50dc8a12";
            config.SubscribeKey = "sub-c-251c704c-3c5f-11e7-ac85-02ee2ddab7fe";
            config.Uuid = username;
            config.LogVerbosity = PNLogVerbosity.BODY;
            config.PubnubLog = new Logger();         
            _pubnub = new Pubnub(config);

            _pubnub.AddListener(this);

            _pubnub.Subscribe<string>()
                .Channels(new string[] { "my_channel" })
                .WithPresence()
                .Execute();
        }

        public override void Message<T>(Pubnub pubnub, PNMessageResult<T> message)
        {
            //the ? is shorthand to check if not null
            MessageReceived?.Invoke(this, new MessageEventArgs
            {
                Channel = message.Channel,
                Message = message.Message.ToString(),
                Subscription = message.Subscription,
                TimeToken = message.Timetoken,
                userMetadata = message.UserMetadata
            });
        }

        public override void Presence(Pubnub pubnub, PNPresenceEventResult presence)
        {
            //the ? is shorthand to check if not null
            PresenceReceived?.Invoke(this, new PresenceEventArgs
            {
                Channel = presence.Channel,
                Event = presence.Event,
                Join = presence.Join,
                Leave = presence.Leave,
                Occupancy = presence.Occupancy,
                State = presence.State,
                Subscription = presence.Subscription,
                Timeout = presence.Timeout,
                Timestamp = presence.Timestamp,
                TimeToken = presence.Timetoken,
                userMetadata = presence.UserMetadata,
                Uuid = presence.Uuid
            });
        }
        public override void Status(Pubnub pubnub, PNStatus status)
        {
            //the ? is shorthand to check if not null
            StatusReceived?.Invoke(this, new StatusEventArgs
            {
                Uuid = status.Uuid,
                StatusCode = status.StatusCode,
                AffectedChannelGroups = status.AffectedChannelGroups,
                AffectedChannels = status.AffectedChannels,
                AuthKey = status.AuthKey,
                Category = status.Category,
                ClientRequest = status.ClientRequest,
                Error = status.Error,
                ErrorData = status.ErrorData,
                Operation = status.Operation,
                Origin = status.Origin,
                TlsEnabled = status.TlsEnabled
            });
        }

        public void PublishMessage(string text)
        {
            _pubnub.Publish()
                .Channel("my_channel")
                .Message(text)
                .Async(new PubnubResult());
        }
    }
}

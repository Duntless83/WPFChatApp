using PubnubApi;

namespace ChatApp
{
    public delegate void UiEventHandler(object source, MyEventArgs e);
    public class PubnubWrapper
    {
        private Pubnub _pubnub;

        public event UiEventHandler OnPresence;
        public event UiEventHandler OnMessage;
        public event UiEventHandler OnStatus;
        public void Initialise(string username)
        {
            PNConfiguration config = new PNConfiguration();
            config.PublishKey = "pub-c-667861b4-2631-4779-9264-c94b50dc8a12";
            config.SubscribeKey = "sub-c-251c704c-3c5f-11e7-ac85-02ee2ddab7fe";
            config.Uuid = username;
            config.LogVerbosity = PNLogVerbosity.BODY;
            config.PubnubLog = new Logger();         
            _pubnub = new Pubnub(config);

            var listener = new PubnubListener(_pubnub);
            listener.OnPresence += Listener_OnPresence; ;
            listener.OnStatus += Listener_OnStatus;
            listener.OnMessage += Listener_OnMessage;

            _pubnub.AddListener(listener);

            _pubnub.Subscribe<string>()
                .Channels(new string[] { "my_channel" })
                .WithPresence()
                .Execute();
        }

        private void Listener_OnMessage(object source, MyEventArgs e)
        {
            OnMessage(this, new MyEventArgs(e.GetInfo()));
        }

        private void Listener_OnPresence(object source, MyEventArgs e)
        {
            OnPresence(this, new MyEventArgs(e.GetInfo()));
        }

        private void Listener_OnStatus(object source, MyEventArgs e)
        {
            OnStatus(this, new MyEventArgs(e.GetInfo()));
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

using ChatApp.Interface;

namespace ChatApp
{
    class ChatController : IChatController
    {
        private readonly IPubnubWrapper _wrapper;

        private bool _successfulLogin;
        public ChatController(IPubnubWrapper wrapper)
        {
            _wrapper = wrapper;

            _successfulLogin = false;

            _wrapper.StatusReceived += _wrapper_StatusReceived;
            _wrapper.PresenceReceived += _wrapper_PresenceReceived;
            _wrapper.MessageReceived += _wrapper_MessageReceived;
        }

        public bool Login(string username)
        {
            _wrapper.Initialise(username);

            while(!_successfulLogin)
            { }

            return _successfulLogin;
        }

        private void _wrapper_MessageReceived(object sender, Events.MessageEventArgs e)
        {

        }


        private void _wrapper_PresenceReceived(object sender, Events.PresenceEventArgs e)
        {
            
        }

        private void _wrapper_StatusReceived(object sender, Events.StatusEventArgs e)
        {
            if (e.StatusCode == 200)
                _successfulLogin = true;
        }
    }
}

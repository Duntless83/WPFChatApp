using System;

namespace ChatApp.Events
{
    public class SuccessfulLogin : EventArgs
    {
        public bool LoggedIn { get; set; }
    }
}

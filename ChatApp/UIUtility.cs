using System;
using System.Windows;
using System.Windows.Controls;

namespace ChatApp
{
    public static class UIUtility
    {
        public static void HandleInvokeRequired<T>(this T control, Action<T> action) where T : Control
        {
            //Check to see is the control is not null
            if (control == null)
                throw new ArgumentNullException(string.Format("Cannot execute {0} on {1}.  {1} is null.", action, control));

            //Check to see if the control is disposed.
            //if (PresentationSource.FromVisual(control).IsDisposed)
            //    throw new ObjectDisposedException(string.Format("Cannot execute {0} on {1}.  {1} is disposed.", action, control));

            //Check to see if the control's InvokeRequired property is true
            if (control.Dispatcher.CheckAccess())
            {
                try
                {
                    //Perform the action
                    action(control);
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Cannot execute {0} on {1}.  {2}.", action, control, ex.Message));
                }
            }
            else
            {
                try
                {
                    //Use Invoke() to invoke your action
                    control.Dispatcher.Invoke(action, new object[] { control });
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Cannot execute {0} on {1}.  {2}.", action, control, ex.Message));
                }
            }
        }
    }
}

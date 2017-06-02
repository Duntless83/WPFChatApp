using PubnubApi;
using System.Diagnostics;

namespace ChatApp
{
    public class Logger : IPubnubLog
    {
        private string logFilePath = "";

        public Logger()
        {
            // Get folder path may vary based on environment
            string folder = System.IO.Directory.GetCurrentDirectory(); //For console
                                                                       //string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // For iOS
            System.Diagnostics.Debug.WriteLine(folder);
            logFilePath = System.IO.Path.Combine(folder, "pubnubmessaging.log");
            Trace.Listeners.Add(new TextWriterTraceListener(logFilePath));
        }

        public void WriteToLog(string log)
        {
            //Save to text file or DB or any storage
            Trace.WriteLine(log);
            Trace.Flush();
        }
    }
}

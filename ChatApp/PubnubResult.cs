using System;
using PubnubApi;

namespace ChatApp
{
    class PubnubResult : PNCallback<PNPublishResult>
    {
        public override void OnResponse(PNPublishResult result, PNStatus status)
        {
            Console.WriteLine("-------");
            Console.WriteLine(status.Uuid);
            Console.WriteLine(status.StatusCode);
            Console.WriteLine(result.Timetoken);

        }
    }
}

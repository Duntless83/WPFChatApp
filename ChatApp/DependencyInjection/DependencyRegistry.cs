using ChatApp.Interface;
using StructureMap;

namespace ChatApp.DependencyInjection
{
    public class DependencyRegistry : Registry
    {
        public DependencyRegistry()
        {
            For<IPubnubWrapper>()
                .Singleton()
                .Use<PubnubWrapper>();

            For<IChatController>()
                .Singleton()
                .Use<ChatController>();
        } 
    }
}

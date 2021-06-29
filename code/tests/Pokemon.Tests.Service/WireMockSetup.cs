
using WireMock.Server;

namespace Pokemon.Tests.Service
{
    public static class WireMockSetup
    {
        public static WireMockServer WireMockServer { get; private set; }

        public static void StartServer()
        {
            WireMockServer = WireMockServer.Start(1234);
        }
    }
}

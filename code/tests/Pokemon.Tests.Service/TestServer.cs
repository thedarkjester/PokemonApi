using Pokemon.Tests.Service;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System;

namespace Pokemon.Tests.Service
{
    namespace Pokemon.Tests.Service
    {
        internal static class TestServer
        {
            private static WebApplicationFactory<Startup> Instance { get; set; }

            public static HttpClient GetClient() => Instance?.CreateDefaultClient()
               ?? throw new InvalidOperationException($"{nameof(TestServer)} not initialized.");

            public static void Initialize()
            {
                Instance = new WebApplicationFactory<Startup>();
                Instance.CreateDefaultClient();
            }

            public static void Dispose() => Instance.Dispose();
        }
    }
}

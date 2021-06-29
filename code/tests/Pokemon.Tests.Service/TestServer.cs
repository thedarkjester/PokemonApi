using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System;
using Microsoft.Extensions.Configuration;

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
                Instance = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
                {
                builder.ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        config.AddJsonFile("appsettings.json");
                        config.AddJsonFile("appsettings.Development.json");
                        config.AddJsonFile("appsettings.servicetest.json");
                    });
                });

   

                Instance.CreateDefaultClient();
            }

            public static void Dispose() => Instance.Dispose();
        }
    }
}

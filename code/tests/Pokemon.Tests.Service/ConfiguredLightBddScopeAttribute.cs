using Pokemon.Tests.Service;
using LightBDD.Core.Configuration;
using LightBDD.Framework.Configuration;
using LightBDD.Framework.Reporting.Formatters;
using LightBDD.NUnit3;
using NUnit.Framework;
using Pokemon.Tests.Service.Pokemon.Tests.Service;

[assembly: Parallelizable(ParallelScope.Fixtures)]

[assembly: ConfiguredLightBddScope]
namespace Pokemon.Tests.Service
{
    /// <summary>
    /// This class extends LightBddScopeAttribute and allows to customize the default configuration of LightBDD.
    /// It is also possible here to override OnSetUp() and OnTearDown() methods to execute code that has to be run once, before or after all tests.
    /// </summary>
    internal class ConfiguredLightBddScopeAttribute : LightBddScopeAttribute
    {
        /// <summary>
        /// This method allows to customize LightBDD behavior.
        /// The code below configures LightBDD to produce also a plain text report after all tests are done.
        /// More information on what can be customized can be found on wiki: https://github.com/LightBDD/LightBDD/wiki/LightBDD-Configuration#configurable-lightbdd-features 
        /// </summary>
        protected override void OnConfigure(LightBddConfiguration configuration)
        {
            configuration
                .ReportWritersConfiguration()
                .AddFileWriter<XmlReportFormatter>("~\\Reports\\FeaturesReport.xml")
                .AddFileWriter<PlainTextReportFormatter>("~\\Reports\\{TestDateTimeUtc:yyyy-MM-dd-HH_mm_ss}_FeaturesReport.txt");
        }

        protected override void OnSetUp()
        {
            WireMockSetup.StartServer();
            TestServer.Initialize();
        }

        protected override void OnTearDown()
        {
            WireMockSetup.WireMockServer.Stop();
            WireMockSetup.WireMockServer.Dispose();
            TestServer.Dispose();
        }
    }
}

using LightBDD.Framework;
using LightBDD.NUnit3;
using System.Threading.Tasks;
using LightBDD.Framework.Scenarios;
using System.Net;

namespace Pokemon.Tests.Service.Features
{
    [FeatureDescription(
    @"In order to allow traffic
    As a Load Balancer
    I want the healthcheck to return an OK result")]
    [Label("Pokemon-scaffold-epic")]
    public partial class HealthCheckEndpoint
    {
        [Scenario]
        [Label("Pokemon-1")]
        [ScenarioCategory(Categories.HealthCheck)]
        public async Task Healthcheck_returns_OK()
        {
           await Runner.RunScenarioAsync(
                     _ => Given_an_http_client(),
                     _ => When_I_call_the_healthcheck_endpoint(),
                     _ => Then_I_should_receive_a_valid_StatusCode(HttpStatusCode.OK));
        }
    }
}

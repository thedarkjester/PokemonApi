using LightBDD.NUnit3;
using NUnit.Framework;
using Pokemon.Tests.Service.Pokemon.Tests.Service;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Json;
using System.Text.Json;
using Pokemon.ApiModels;

namespace Pokemon.Tests.Service.Features
{
    public partial class HealthCheckEndpoint : FeatureFixture
    {
        private JsonSerializerOptions serializationOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        private HttpClient _httpClient;
        private HttpResponseMessage _response;

        private Task Given_an_http_client()
        {
            _httpClient = TestServer.GetClient();
            return Task.CompletedTask;
        }

        private async Task When_I_call_the_healthcheck_endpoint()
        {
            _response = await _httpClient.GetAsync("/healthcheck");
        }
        private async Task Then_I_should_receive_a_valid_StatusCode(HttpStatusCode statusCode)
        {
            Assert.AreEqual(statusCode, _response.StatusCode,"Status code is not OK");

            HealthCheckResponse healthCheckResponse = null;

            using (var jsonStream = await _response.Content.ReadAsStreamAsync())
            {
                healthCheckResponse = await JsonSerializer.DeserializeAsync<HealthCheckResponse>(jsonStream, serializationOptions);
            }

            Assert.IsNotNull(healthCheckResponse,"Healthcheck should not be null");
            Assert.True(healthCheckResponse.IsHealthy, "The service should be healthy");
            Assert.IsNull(healthCheckResponse.HealthCheckErrors,"The error collection should be null");
        }
    }
}

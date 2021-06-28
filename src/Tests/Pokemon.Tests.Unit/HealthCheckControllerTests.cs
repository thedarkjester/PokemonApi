using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Pokemon.ApiModels;
using Pokemon.Controllers;
using System.Threading.Tasks;

namespace Pokemon.Tests.Unit
{
    public class HealthCheckControllerTests
    {
        private HealthCheckController _healthCheckController;

        [SetUp]
        public void Setup()
        {
            _healthCheckController = new HealthCheckController();
        }

        [Test]
        public async Task Default_Return_Is_Ok()
        {
            var response = await _healthCheckController.Get();
            Assert.IsAssignableFrom<ActionResult<HealthCheckResponse>>(response);

            var result3 = (ObjectResult)response.Result;
            var healthCheckResponse = result3.Value as HealthCheckResponse;
            Assert.IsNotNull(healthCheckResponse, "Healthcheck should not be null");
            Assert.True(healthCheckResponse.IsHealthy, "The service should be healthy");
            Assert.IsNull(healthCheckResponse.HealthCheckErrors, "The error collection should be null");
        }
    }
}
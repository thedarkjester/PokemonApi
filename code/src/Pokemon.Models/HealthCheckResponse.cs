using System.Collections.Generic;

namespace Pokemon.ApiModels
{
    public class HealthCheckResponse
    {
        public bool IsHealthy { get; set; }
        public IEnumerable<HealthCheckError> HealthCheckErrors { get; set; }
    }
}

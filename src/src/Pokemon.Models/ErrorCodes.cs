namespace Pokemon.ApiModels
{
    public static class ErrorCodes
    {
        public const string DownStreamServiceUnavailable = "downstream.unavailable";
        public const string DownStreamServiceError = "downstream.error";
        public const string DownStreamServiceRateLimited = "downstream.rateLimited";
        public const string PokemonNotFound = "pokemon.notFound";
    }
}
namespace Pokemon.ApiModels
{
    public class PokemonOverview
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Habitat { get; set; } // this could be an enum, but wanted to keep it simple
        public bool IsLegendary { get; set; }
    }
}

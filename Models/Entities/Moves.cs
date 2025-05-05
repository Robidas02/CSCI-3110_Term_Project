using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CSCI_3110_Term_Project.Models.Entities
{
    /// <summary>
    /// The Move objects are tied to Pokemon objects.
    /// They are applied to Pokemon Instance objects to create a fully fledged pokemon.
    /// </summary>
    public class Moves
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Type Type { get; set; }
        public Category Category { get; set; }
        public int Power { get; set; }
        public int Accuracy { get; set; }
        public int PowerPoints { get; set; }
        public string Description { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<Pokemon> ViablePokemon { get; set; } 
            = new List<Pokemon>();
        public ICollection<PokemonInstance> KnownBy {  get; set; }
            = new List<PokemonInstance>();
    }
}

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CSCI_3110_Term_Project.Models.Entities
{
    /// <summary>
    /// This class is meant to store Ability objects which are tied to Pokemon objects.
    /// These can be applied to Pokemon Instance objects to create a full fledged pokemon.
    /// </summary>
    public class Abilities
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<Pokemon> ViablePokemon { get; set; }
            = new List<Pokemon>();
    }
}

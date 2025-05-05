using System.ComponentModel.DataAnnotations;

namespace CSCI_3110_Term_Project.Models.Entities
{
    /// <summary>
    /// Pokemon objects are used to hold data about a pokemon.
    /// They are applied to Pokemon Instance objects to create a fully fledged pokemon.
    /// </summary>
    public class Pokemon
    {
        [Key]
        public int Id { get; set; }
        public int DexNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public Type Type1 { get; set; }
        public Type Type2 { get; set; }
        public ICollection<Moves> Moves { get; set; }
            = new List<Moves>();
        public ICollection<Abilities> Abilities { get; set; }
            = new List<Abilities>();
    }
}

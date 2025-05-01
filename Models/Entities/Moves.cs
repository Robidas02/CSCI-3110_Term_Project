using System.ComponentModel.DataAnnotations;

namespace CSCI_3110_Term_Project.Models.Entities
{
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
        public ICollection<Pokemon> ViablePokemon { get; set; } 
            = new List<Pokemon>();
        public ICollection<PokemonInstance> KnownBy {  get; set; }
            = new List<PokemonInstance>();
    }
}

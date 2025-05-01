using System.ComponentModel.DataAnnotations;

namespace CSCI_3110_Term_Project.Models.Entities
{
    public class Abilities
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Pokemon> ViablePokemon { get; set; }
            = new List<Pokemon>();
    }
}

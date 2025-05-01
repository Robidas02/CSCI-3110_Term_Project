using System.ComponentModel.DataAnnotations;

namespace CSCI_3110_Term_Project.Models.Entities
{
    public class Teams
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<PokemonInstance> PokemonInstances { get; set; } 
            = new List<PokemonInstance>();
    }
}

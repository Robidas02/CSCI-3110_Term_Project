using System.ComponentModel.DataAnnotations;

namespace CSCI_3110_Term_Project.Models.Entities
{
    public class Pokemon
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Type Type1 { get; set; }
        public Type Type2 { get; set; }
        public ICollection<Moves> Moves { get; set; }
            = new List<Moves>();
        public ICollection<Abilities> Abilities { get; set; }
            = new List<Abilities>();
    }
}

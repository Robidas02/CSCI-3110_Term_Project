using System.ComponentModel.DataAnnotations;

namespace CSCI_3110_Term_Project.Models.Entities
{
    /// <summary>
    /// The Item object holds data on Items. These can be applied to Pokemon Instance objects to create a fully fledged pokemon
    /// </summary>
    public class Items
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

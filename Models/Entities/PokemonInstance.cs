// NOTE: ChatGPT helped me a lot with the creation of this class.
// I was confused as to how to have multiple instances of the same Pokemon with variance in the Item, Ability, etc.
// And it told me to make an instance class. So I did.

using System.ComponentModel.DataAnnotations;

namespace CSCI_3110_Term_Project.Models.Entities;

public class PokemonInstance
{
    [Key]
    public int Id { get; set; }

    public int PokemonSpeciesId { get; set; }
    public Pokemon PokemonSpecies { get; set; } = new();

    public int TeamId { get; set; }
    public Teams Team { get; set; } = new();

    public int? ItemId { get; set; }
    public Items? Item { get; set; }


    public int? AbilityId { get; set; }
    public Abilities? Ability { get; set; }

    public List<Moves> Move { get; set; } = new();
}

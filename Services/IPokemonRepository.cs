using CSCI_3110_Term_Project.Models.Entities;

namespace CSCI_3110_Term_Project.Services;

public interface IPokemonRepository
{
    Task<ICollection<Pokemon>> ReadAllAsync();
    Task<Pokemon> ReadAsync(int id);
}

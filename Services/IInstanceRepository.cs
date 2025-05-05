using CSCI_3110_Term_Project.Models.Entities;
namespace CSCI_3110_Term_Project.Services
{
    /// <summary>
    /// An Interface for the repository for the PokemonInstance class and controller.
    /// </summary>
    public interface IInstanceRepository
    {
        Task<PokemonInstance> ReadAsync(int id);
        Task<PokemonInstance> CreateAsync(PokemonInstance newInstance);
        Task UpdateAsync(int id, PokemonInstance instance, List<int> ChosenMoveID);
        Task DeleteAsync(int id);
    }
}

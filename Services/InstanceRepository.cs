using CSCI_3110_Term_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSCI_3110_Term_Project.Services
{
    /// <summary>
    /// The repository for the PokemonInstance class and controller.
    /// </summary>
    public class InstanceRepository : IInstanceRepository
    {
        private readonly ApplicationDbContext _db;

        public InstanceRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Performs a single read for a PokemonInstance object
        /// </summary>
        /// <param name="id">The Id of the object</param>
        /// <returns>The found object</returns>
        public async Task<PokemonInstance?> ReadAsync(int id)
        {
            return await _db.PokemonInstance
                .Include(pI => pI.Move)
                .Include(pI => pI.Ability)
                .FirstOrDefaultAsync(pI => pI.Id == id);
        }

        /// <summary>
        /// Creates a new PokemonInstance object.
        /// </summary>
        /// <param name="newInstance">The new object</param>
        /// <returns>The created object</returns>
        public async Task<PokemonInstance> CreateAsync(PokemonInstance newInstance)
        {
            await _db.PokemonInstance.AddAsync(newInstance);
            await _db.SaveChangesAsync();
            return newInstance;
        }

        /// <summary>
        /// Updates the PokemonInstance object by doing a single read using the old objects Id and then updating each field.
        /// </summary>
        /// <param name="oldId">The ID of the previous PokemonInstance object</param>
        /// <param name="instance">The new PokemonInstance object</param>
        /// <param name="ChosenMoveID">A list of Moves chosen by the user.</param>
        /// <returns>N/A</returns>
        public async Task UpdateAsync(int oldId, PokemonInstance instance, List<int> ChosenMoveID)
        {
            PokemonInstance? instanceToUpdate = await ReadAsync(oldId);
            if (instanceToUpdate != null)
            {
                instanceToUpdate.PokemonSpecies = instance.PokemonSpecies;
                instanceToUpdate.AbilityId = instance.AbilityId;
                instanceToUpdate.ItemId = instance.ItemId;

                // This bit with the updating moves is straight from ChatGPT
                instanceToUpdate.Move.Clear();
                var newMoves = await _db.Moves
                    .Where(m => ChosenMoveID.Contains(m.Id))
                    .ToListAsync();

                foreach (var move in newMoves)
                {
                    instanceToUpdate.Move.Add(move);
                }
                await _db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Deletes a PokemonInstance object
        /// </summary>
        /// <param name="id">The ID of the object</param>
        /// <returns>N/A</returns>
        public async Task DeleteAsync(int id)
        {
            PokemonInstance? instanceToDelete = await ReadAsync(id);
            if (instanceToDelete != null)
            {
                _db.PokemonInstance.Remove(instanceToDelete);
                await _db.SaveChangesAsync();
            }
        }
    }
}

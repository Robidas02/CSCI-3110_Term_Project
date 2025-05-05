using CSCI_3110_Term_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSCI_3110_Term_Project.Services
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly ApplicationDbContext _db;

        public PokemonRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Retrieves all Pokemon objects from the database
        /// </summary>
        /// <returns>The Pokemon objects</returns>
        public async Task<ICollection<Pokemon>> ReadAllAsync()
        {
            return await _db.Pokemon
                .Include(p => p.Abilities)
                .Include(p => p.Moves)
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves a single Pokemon object
        /// </summary>
        /// <param name="id">The ID of the object</param>
        /// <returns>The Pokemon object</returns>
        public async Task<Pokemon?> ReadAsync(int id)
        {
            return await _db.Pokemon
                .Include(p => p.Abilities)
                .Include(p => p.Moves)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}

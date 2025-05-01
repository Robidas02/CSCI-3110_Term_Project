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
        public async Task<ICollection<Pokemon>> ReadAllAsync()
        {
            return await _db.Pokemon.ToListAsync();
        }
    }
}

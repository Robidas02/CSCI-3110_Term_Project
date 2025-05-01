using CSCI_3110_Term_Project.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace CSCI_3110_Term_Project.Services
{
    [Authorize]
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _db;

        public TeamRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ICollection<Teams>> ReadAllAsync(string? userId)
        {
            return await _db.Teams.Where(t => t.UserId == userId).ToListAsync();
        }

        public async Task<Teams?> ReadAsync(int id)
        {
            // Includes are for setting up the partial view for each PokemonInstance in a Team.
            var team = await _db.Teams
                .Include(t => t.PokemonInstances)
                    .ThenInclude(p => p.PokemonSpecies)
                .Include(t => t.PokemonInstances)
                    .ThenInclude(p => p.Item)
                .Include(t => t.PokemonInstances)
                    .ThenInclude(p => p.Ability)
                .Include(t => t.PokemonInstances)
                    .ThenInclude(p => p.Move)
                .FirstOrDefaultAsync(t => t.Id == id); 
            return team;
        }
    }
}

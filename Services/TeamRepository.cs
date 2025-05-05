using CSCI_3110_Term_Project.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace CSCI_3110_Term_Project.Services
{
    /// <summary>
    /// The repository for the Teams object and controller
    /// </summary>
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _db;

        public TeamRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Reads all Teams from the database
        /// </summary>
        /// <param name="userId">The id of the current user</param>
        /// <returns>A list of Team objects</returns>
        public async Task<ICollection<Teams>> ReadAllAsync(string? userId)
        {
            return await _db.Teams.Where(t => t.UserId == userId).ToListAsync();
        }

        /// <summary>
        /// Reads a single Team object and loads its corresponding PokemonInstance objects
        /// </summary>
        /// <param name="id">The id of the Team object</param>
        /// <returns>The Team object</returns>
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

        /// <summary>
        /// Creates a new Team object
        /// </summary>
        /// <param name="newTeam">The new Team object</param>
        /// <returns>The created Team object</returns>
        public async Task<Teams> CreateAsync(Teams newTeam)
        {
            await _db.Teams.AddAsync(newTeam);
            await _db.SaveChangesAsync();
            return newTeam;
        }

        /// <summary>
        /// Updates a Team object
        /// </summary>
        /// <param name="oldId">The id of the previous object</param>
        /// <param name="team">The updated Team object</param>
        /// <returns>N/A</returns>
        public async Task UpdateAsync(int oldId, Teams team)
        {
            Teams? teamToUpdate = await ReadAsync(oldId);
            if (teamToUpdate != null)
            {
                teamToUpdate.Name = team.Name;
                teamToUpdate.Description = team.Description;
                await _db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Deletes a Team object and all corresponding PokemonInstances
        /// </summary>
        /// <param name="id">The id of the Team being deleted</param>
        /// <returns>N/A</returns>
        public async Task DeleteAsync(int id)
        {
            Teams? teamToDelete = await ReadAsync(id);
            if (teamToDelete != null)
            {
                _db.Teams.Remove(teamToDelete);
                await _db.SaveChangesAsync();
            }
        }
    }
}

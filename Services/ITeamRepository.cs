using CSCI_3110_Term_Project.Models.Entities;

namespace CSCI_3110_Term_Project.Services;

public interface ITeamRepository
{
    Task<Teams?> ReadAsync(int id);

    Task<ICollection<Teams>> ReadAllAsync(string? userId);

    Task<Teams> CreateAsync(Teams newTeam);

    Task UpdateAsync(int oldId, Teams team);
    Task DeleteAsync(int id);
}

using CSCI_3110_Term_Project.Models.Entities;

namespace CSCI_3110_Term_Project.Services;

public interface ITeamRepository
{
    Task<Teams?> ReadAsync(int id);

    Task<ICollection<Teams>> ReadAllAsync(string? userId);
}

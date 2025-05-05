using CSCI_3110_Term_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSCI_3110_Term_Project.Services;

public class ItemRepository : IItemRepository
{
    private readonly ApplicationDbContext _db;

    public ItemRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    /// <summary>
    /// Retrieves every Item object from the database
    /// </summary>
    /// <returns>The Item objects</returns>
    public async Task<ICollection<Items>> ReadAllAsync()
    {
        return await _db.Items.ToListAsync();
    }
}

using CSCI_3110_Term_Project.Models.Entities;

namespace CSCI_3110_Term_Project.Services
{
    public interface IItemRepository
    {
        Task<ICollection<Items>> ReadAllAsync();
    }
}

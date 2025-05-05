using CSCI_3110_Term_Project.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSCI_3110_Term_Project.Controllers
{
    /// <summary>
    /// Controller for the Item class
    /// </summary>
    [Route("api/item")]
    [ApiController]
    [AllowAnonymous]
    public class ItemController : Controller
    {
        private IItemRepository _itemRepo;

        public ItemController(IItemRepository itemRepo)
        {
            _itemRepo = itemRepo;
        }

        /// <summary>
        /// Loads the Index View
        /// </summary>
        /// <returns>The Index View</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Retrieves all Item objects from the database
        /// </summary>
        /// <returns>The Item list JSON</returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var itemList = await _itemRepo.ReadAllAsync();
            return Ok(itemList);
        }
    }
}

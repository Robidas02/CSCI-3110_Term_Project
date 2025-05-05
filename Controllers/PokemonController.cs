using CSCI_3110_Term_Project.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSCI_3110_Term_Project.Controllers
{
    /// <summary>
    /// Controller for the Pokemon class
    /// </summary>
    [Route("api/pokemon")]
    [ApiController]
    [AllowAnonymous]
    public class PokemonController : Controller
    {
        private IPokemonRepository _pokeRepo;

        public PokemonController(IPokemonRepository pokeRepo)
        {
            _pokeRepo = pokeRepo;
        }

        /// <summary>
        /// Loads the Index View for the Pokemon class
        /// </summary>
        /// <returns>The Index View</returns>
        public async Task<IActionResult> Index()
        {
            return View();
        }

        /// <summary>
        /// Retrieves all entries from the Pokemon database table
        /// </summary>
        /// <returns>The result as JSON</returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var pokeList = await _pokeRepo.ReadAllAsync();
            return Ok(pokeList);
        }

        /// <summary>
        /// Retrieves a single pokemon object from the database
        /// </summary>
        /// <param name="id">The ID of the Pokemon</param>
        /// <returns>The object as JSON</returns>
        [HttpGet("one/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var mon = await _pokeRepo.ReadAsync(id);
            return Ok(mon);
        }
    }
}

using CSCI_3110_Term_Project.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSCI_3110_Term_Project.Controllers
{
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

        public async Task<IActionResult> Index()
        {
            return View(); // await _pokeRepo.ReadAllAsync());
            //var pokeList = await _pokeRepo.ReadAllAsync();
            //return Ok(pokeList);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var pokeList = await _pokeRepo.ReadAllAsync();
            return Ok(pokeList);
        }
    }
}

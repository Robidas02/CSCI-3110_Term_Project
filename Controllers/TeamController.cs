using Microsoft.AspNetCore.Mvc;
using CSCI_3110_Term_Project.Services;
using System.Security.Claims;

namespace CSCI_3110_Term_Project.Controllers
{
    [Route("api/team")]
    [ApiController]
    public class TeamController : Controller
    {
        private ITeamRepository _teamRepo;

        public TeamController(ITeamRepository teamRepo)
        {
            _teamRepo = teamRepo;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Index()
        {
            string? currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(await _teamRepo.ReadAllAsync(currentUserId));
        }

        [HttpGet("one/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var team = await _teamRepo.ReadAsync(id);
            string? currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(team == null)
            {
                return RedirectToAction("Index");
            }
            if(team.UserId != currentUserId)
            {
                return RedirectToAction("Index");
            }
            return View(team);
        }
    }
}

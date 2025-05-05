using Microsoft.AspNetCore.Mvc;
using CSCI_3110_Term_Project.Services;
using System.Security.Claims;
using CSCI_3110_Term_Project.Models.Entities;
using Microsoft.AspNetCore.Authorization;

namespace CSCI_3110_Term_Project.Controllers
{
    /// <summary>
    /// The controller for the Teams class.
    /// </summary>
    [Route("api/team")]
    [ApiController]
    [Authorize]
    public class TeamController : Controller
    {
        private ITeamRepository _teamRepo;

        public TeamController(ITeamRepository teamRepo)
        {
            _teamRepo = teamRepo;
        }

        /// <summary>
        /// Creates the Index View which shows all Teams
        /// </summary>
        /// <returns>The Index View</returns>
        [HttpGet("all")]
        public async Task<IActionResult> Index()
        {
            string? currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(await _teamRepo.ReadAllAsync(currentUserId));
        }

        /// <summary>
        /// Shows the Details View for a particular Team
        /// </summary>
        /// <param name="id">The id of the Team</param>
        /// <returns>The Details View</returns>
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

        /// <summary>
        /// The Create View for the Teams class
        /// </summary>
        /// <returns>The Create View</returns>
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a new Team object
        /// </summary>
        /// <param name="newTeam">The new Team object from the form</param>
        /// <returns>The Index View</returns>
        [HttpPost("create"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Teams newTeam)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            newTeam.UserId = userId;

            if (ModelState.IsValid)
            {
                await _teamRepo.CreateAsync(newTeam);
                return RedirectToAction("Index");
            }
            return View(newTeam);
        }

        /// <summary>
        /// Gets the Edit View for the Team object
        /// </summary>
        /// <param name="id">The id of the Team object</param>
        /// <returns>The Edit View</returns>
        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var team = await _teamRepo.ReadAsync(id);
            if (team == null)
            {
                return RedirectToAction("Index");
            }
            return View(team);
        }

        /// <summary>
        /// Edits the Team object
        /// </summary>
        /// <param name="team">The Team object from the form</param>
        /// <returns>The Index View</returns>
        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromForm] Teams team)
        {
            if (ModelState.IsValid)
            {
                await _teamRepo.UpdateAsync(team.Id, team);
                return RedirectToAction("Index");
            }
            return View(team);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var team = await _teamRepo.ReadAsync(id);
            if (team == null)
            {
                return RedirectToAction("Index");
            }
            return View(team);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _teamRepo.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}

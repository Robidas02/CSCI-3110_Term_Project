using Microsoft.AspNetCore.Mvc;
using CSCI_3110_Term_Project.Models.Entities;
using CSCI_3110_Term_Project.Services;

namespace CSCI_3110_Term_Project.Controllers
{
    /// <summary>
    /// The controller for the PokemonInstance class.
    /// </summary>
    public class PokemonInstanceController : Controller
    {
        private IInstanceRepository _instanceRepo;

        public PokemonInstanceController(IInstanceRepository instanceRepo)
        {
            _instanceRepo = instanceRepo;
        }

        /// <summary>
        /// Create View for the PokemonInstance object
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create(int teamId)
        {
            ViewBag.teamId = teamId;
            return View();
        }

        /// <summary>
        /// Creates a new PokemonInstance object
        /// </summary>
        /// <param name="newInstance">The new PokemonInstance object</param>
        /// <returns>The Details View of the Team controller</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] PokemonInstance newInstance)
        {
            if (ModelState.IsValid)
            {
                await _instanceRepo.CreateAsync(newInstance);
                return RedirectToAction("Details", "Team", new { id = newInstance.TeamId });
            }
            return View(newInstance);
        }

        /// <summary>
        /// Redirects to the Edit View
        /// </summary>
        /// <param name="id">The ID of the PokemonInstance you want to edit</param>
        /// <returns>The Edit View</returns>
        [HttpGet] 
        public async Task<IActionResult> Edit(int id)
        {
            var instanceToEdit = await _instanceRepo.ReadAsync(id);

            if(instanceToEdit != null) 
            {
                return View(instanceToEdit);
            }
            return NotFound();
        }

        /// <summary>
        /// Edits the PokemonInstance
        /// </summary>
        /// <param name="instance">The isntance object from the form</param>
        /// <param name="ChosenMoveID">A list of Move objects linked to the PokemonInstance object</param>
        /// <returns>The Details View for the Teams controller</returns>
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] PokemonInstance instance, [FromForm] List<int> ChosenMoveID)
        {
            // This doesn't work :(
            if (ModelState.IsValid)
            {
                await _instanceRepo.UpdateAsync(instance.Id, instance, ChosenMoveID);
                return RedirectToAction("Details", "Team", new { id = instance.TeamId });
            }
            return View(instance);
        }


        /// <summary>
        /// Brings the user to a Delete View
        /// </summary>
        /// <param name="id">The id of the PokemonInstance to be deleted</param>
        /// <returns>The View</returns>
        public async Task<IActionResult> Delete(int id)
        {
            var instanceToDelete = await _instanceRepo.ReadAsync(id);
            if (instanceToDelete == null)
            {
                return RedirectToAction("Index", "Team");
            }
            return View(instanceToDelete);
        }

        /// <summary>
        /// Deletes the PokemonInstance
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <returns>The Index View for the Teams object</returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _instanceRepo.DeleteAsync(id);
            return RedirectToAction("Index", "Team");
        }
    }
}

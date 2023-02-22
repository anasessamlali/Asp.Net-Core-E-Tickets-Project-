using E_Tickets.Data;
using E_Tickets.Data.Services;
using E_Tickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace E_Tickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        public async  Task<IActionResult> Index()
        {
             var data = await _service.GetAllAsync();
            return View(data);
        }
        public IActionResult Create()    //GET:Actors/Create
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor) 
        {
            if (!ModelState.IsValid)
            {
                return View(actor); 
            }
           await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get//Details Actors / 1(id)

        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);

        }
        public async Task<IActionResult>  Edit(int id)    //GET:Actors/EDIT/ ID
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)    //GET:Actors/Delete/ ID
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");

            await _service.DeleteAsync(id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}

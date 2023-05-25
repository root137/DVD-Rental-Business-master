using Microsoft.AspNetCore.Mvc;
using DVDRental.Models;
using Microsoft.EntityFrameworkCore;


namespace DVDRental.Controllers
{
    public class ActorDVDController : Controller
    {

        private readonly DataBaseContext  _context;

        public ActorDVDController(DataBaseContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchString)
        {
            var dataBaseContext = _context.CastMember.Include(d=>d.Actor).Include(d=>d.DVDTitle);

            var actors = from a in dataBaseContext select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                actors = actors.Where(d => d.Actor.ActorSurname.Contains(searchString));
            }
            return View(actors.ToList());
        }
    }
}

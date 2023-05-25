using Microsoft.AspNetCore.Mvc;
using DVDRental.Models;
using Microsoft.EntityFrameworkCore;


namespace DVDRental.Controllers
{
    public class DVDDetailsController : Controller
    {

        private readonly DataBaseContext  _context;

        public DVDDetailsController (DataBaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dataBaseContext = _context.DVDTitle.Include(d=>d.Producer).Include(d=>d.Studio).OrderBy(u=>u.DateReleased).ToList();

            foreach (var item in dataBaseContext)
            {
                List<string> actors_list = _context.CastMember
                    .Where(a => a.DVDNumber == item.DVDNumber)
                    .Include(c => c.Actor).OrderBy(a=>a.Actor.ActorSurname).Select(a=>a.Actor.ActorFirstName+ " "+  a.Actor.ActorSurname).ToList();
                string actors = string.Join(", ", actors_list);
                item.actors = actors;
            }
            return View(dataBaseContext);
        }
    }
}

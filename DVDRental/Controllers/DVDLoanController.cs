using Microsoft.AspNetCore.Mvc;
using DVDRental.Models;
using Microsoft.EntityFrameworkCore;


namespace DVDRental.Controllers
{
    public class DVDLoanController: Controller
    {

        private readonly DataBaseContext  _context;

        public DVDLoanController(DataBaseContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchString)
        {
            var dataBaseContext = _context.Loan;

            if (!String.IsNullOrEmpty(searchString))
            {
                var loan = dataBaseContext.Where(l => l.MemberNumber == int.Parse(searchString)).Include(l=>l.DVDCopy)
                    .ThenInclude(dc=>dc.DVDTitle).Include(l=>l.Member).FirstOrDefault();
                return View(loan);
            }
            return View();
        }
    }
}

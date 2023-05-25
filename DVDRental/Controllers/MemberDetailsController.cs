using Microsoft.AspNetCore.Mvc;
using DVDRental.Models;
using Microsoft.EntityFrameworkCore;


namespace DVDRental.Controllers
{
    public class MemberDetails: Controller
    {

        private readonly DataBaseContext  _context;

        public MemberDetails(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dataBaseContext = _context.Member.OrderBy(m=>m.MemberFirstName).Include(m => m.MembershipCategory).ToList();
            dataBaseContext.ForEach(m=>m.LoanCount = _context.Loan.Where(l=>l.MemberNumber == m.MemberNumber && l.DateReturned == null).ToList().Count);
            return View(dataBaseContext.ToList());
        }
    }
}

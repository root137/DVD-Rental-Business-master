using DVDRental.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;




namespace DVDRental.Services
{
    public class UserService
    {
        private readonly DataBaseContext _context;

        public UserService(DataBaseContext context)
        {
            _context = context;
        }

        internal User GetUserById(int UserNumber)
        {
            var appUser = _context.User.Find(UserNumber);
            return appUser;
        }

        internal bool TryValidateUser ( string UserName, string UserType, out List<Claim> claims )
        {
            claims = new List<Claim>();
            var appUser = _context.User
                .Where(a => a.UserName == UserName)
                .Where(a => a.UserType == UserType).FirstOrDefault();

            if(appUser == null)
            {
                return false;
            }
            else
            {
                claims.Add(new Claim("Usernumber", appUser.UserNumber.ToString()));
                claims.Add(new Claim("UserName", appUser.UserName));
                claims.Add(new Claim("UserType", appUser.UserType));
            }

            return true;
        }
    }
}

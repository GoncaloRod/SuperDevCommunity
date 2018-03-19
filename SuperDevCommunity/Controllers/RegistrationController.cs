using SuperDevCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Web.Security;
using System.Text;

namespace SuperDevCommunity.Controllers
{
    public class RegistrationController : Controller
    {
        private SuperDevCommunityContext db = new SuperDevCommunityContext();

        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            bool uniqueUsername = db.Users.Where(u => u.username == user.username).ToList().Count == 0;
            bool uniqueEmail = db.Users.Where(u => u.email == user.email).ToList().Count == 0;

            if (uniqueUsername && uniqueEmail)
            {
                if (ModelState.IsValid)
                {
                    HMACSHA512 encrypt = new HMACSHA512(new byte[] { 1 });

                    var password = encrypt.ComputeHash(Encoding.UTF8.GetBytes(user.password));

                    user.password = Convert.ToBase64String(password);
                    user.retryPassword = user.password;

                    db.Users.Add(user);
                    db.SaveChanges();

                    // Login
                    FormsAuthentication.SetAuthCookie(user.id.ToString(), false);

                    return Redirect("profile");
                }
            }
            else
            {
                if (!uniqueUsername) ModelState.AddModelError("username", "Username is already in use!");
                if (!uniqueEmail) ModelState.AddModelError("email", "Email is already in use!");
            }

            return View(user);
        }
    }
}
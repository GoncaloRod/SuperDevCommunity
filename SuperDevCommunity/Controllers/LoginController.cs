using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Web.Security;
using System.Text;
using SuperDevCommunity.Models;

namespace SuperDevCommunity.Controllers
{
    public class LoginController : Controller
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
            if (user.email != null & user.password != null)
            {
                HMACSHA512 encrypt = new HMACSHA512(new byte[] { 1 });

                var password = encrypt.ComputeHash(Encoding.UTF8.GetBytes(user.password));

                user.password = Convert.ToBase64String(password);

                foreach (var _user in db.Users.ToList())
                {
                    if (_user.email == user.email && _user.password == user.password)
                    {
                        FormsAuthentication.SetAuthCookie(_user.id.ToString(), false);

                        if (Request.QueryString["ReturnUrl"] == null)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return Redirect(Request.QueryString["ReturnUrl"]);
                        }
                    }
                }
            }

            ModelState.AddModelError("email", "Email and Password does not match!");
            user.password = "";
            return View(user);
        }
    }
}
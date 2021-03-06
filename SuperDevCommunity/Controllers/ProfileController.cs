﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using SuperDevCommunity.Models;

namespace SuperDevCommunity.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private SuperDevCommunityContext db = new SuperDevCommunityContext();

        public ActionResult Index()
        {
            User user = db.Users.Find(int.Parse(User.Identity.Name));

            ViewBag.posts = db.Posts.Where(p => p.userId == user.id).ToList();
            ViewBag.comments = db.Comments.Where(c => c.userId == user.id).ToList();
            ViewBag.likes = new List<Post>();

            foreach (var like in db.PostLikes.Where(l => l.userId == user.id))
            {
                ViewBag.likes.Add(db.Posts.Where(p => p.id == like.postId).ToList()[0]);
            }

            return View(user);
        }

        public ActionResult ChangeProfilePic()
        {
            ViewBag.defaultPics = db.DefaultProfilePics.ToList();
            ViewBag.user = db.Users.Find(int.Parse(User.Identity.Name));

            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetDefaultProfilePic(DefaultProfilePic pic)
        {
            // Get logged user
            User user = db.Users.Find(int.Parse(User.Identity.Name));

            // Get pic info
            pic = db.DefaultProfilePics.Find(pic.id);

            if (pic != null)
            {
                user.profilePic = pic.imagePath;

                db.SaveChanges();
                
                return Redirect("/profile");

            }

            return RedirectToAction("ChangeProfilePic");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadProfilePic()
        {
            HttpPostedFileBase pic = Request.Files["uploadPic"];
            
            if (pic != null)
            {
                string extention = Path.GetExtension(pic.FileName);

                if (extention == ".png" || extention == ".jpg" || extention == ".jpeg")
                {
                    User user = db.Users.Find(int.Parse(User.Identity.Name));
                
                    Guid guid = Guid.NewGuid();
                
                    string fileName = $"{guid}-{User.Identity.Name.ToString()}{extention}";

                    user.profilePic = fileName;

                    db.SaveChanges();
                
                    pic.SaveAs($"{Server.MapPath("~/img/profile_pics/")}{fileName}");

                    return Redirect("/profile");
                }
            }
            
            return RedirectToAction("ChangeProfilePic");
        }
    }
}
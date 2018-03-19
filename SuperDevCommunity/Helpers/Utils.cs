using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperDevCommunity.Models;

namespace SuperDevCommunity.Helpers
{
    public static class Utils
    {
        private static SuperDevCommunityContext db = new SuperDevCommunityContext();

        public static User GetUserWithId(this HtmlHelper htmlHelper, int id)
        {
            return db.Users.Find(id);
        }
    }
}
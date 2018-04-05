using System.Data.Entity.Core.Common.CommandTrees;
using System.Web.Mvc;
using SuperDevCommunity.Models;

namespace SuperDevCommunity.Controllers
{
    public class DefaultProfilePicsController : Controller
    {
        private SuperDevCommunityContext db = new SuperDevCommunityContext();

        public string GetImageUrl(int? id)
        {
            if (id != null)
            {
                DefaultProfilePic pic = db.DefaultProfilePics.Find(id);

                if (pic != null) return pic.imagePath;
            }

            return "";
        }
    }
}
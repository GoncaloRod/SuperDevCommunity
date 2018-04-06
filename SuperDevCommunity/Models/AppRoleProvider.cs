using System.Linq;
using System.Web.Security;

namespace SuperDevCommunity.Models
{
    public class AppRoleProvider : RoleProvider
    {
        private SuperDevCommunityContext db = new SuperDevCommunityContext();
        
        public override string ApplicationName { get; set; }

        public override bool IsUserInRole(string username, string roleName)
        {
            int userId = int.Parse(username);
            
            var user = db.Users.Where(u => u.id == userId).First();

            if (user.admin && roleName == "admin") return true;
            if (!user.admin && roleName == "user") return true;
            return false;
        }

        public override string[] GetRolesForUser(string username)
        {
            int userId = int.Parse(username);
            
            var user = db.Users.Where(u => u.id == userId).First();

            if (user.admin) return new string[] {"admin"};
            
            return new string[] {"user"};
        }

        public override bool RoleExists(string roleName)
        {
            return roleName.Equals("admin") || roleName.Equals("user");
        }

        #region NotImplemented

        public override void CreateRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new System.NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new System.NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
namespace MvcProjeKampi.Roles
{
    public class AdminRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return new string[] { };
            }

            username = username.Trim();

            using (Context context = new Context())
            {
                var user = context.Admins.FirstOrDefault(x => x.AdminUserName == username);

                if (user == null && !username.Contains("@"))
                {
                    user = context.Admins.FirstOrDefault(x => x.AdminUserName == username + "@gmail.com");
                }

                if (user == null && username.Contains("@"))
                {
                    var shortName = username.Split('@')[0];
                    user = context.Admins.FirstOrDefault(x => x.AdminUserName == shortName);
                }

                if (user != null && !string.IsNullOrWhiteSpace(user.AdminRole))
                {
                    return new string[] { user.AdminRole.Trim() };
                }
            }

            return new string[] { };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ritual.Booking.Data;
using Ritual.Booking.Web.Models;
using System;
using System.Web.Security;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Ritual.Booking.Web.Controllers
{
    public class ControllerHelper
    {
        public static bool doesUserHaveRolePermissions(string roleName)
        {
            ApplicationDbContext ApplicationDbContext = new ApplicationDbContext();
            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ApplicationDbContext));
            ApplicationUser user = UserManager.FindById(HttpContext.Current.User.Identity.GetUserId());
            int rolecount = 0;
            string[] roleArray = roleName.Split(',');
            foreach (string role in roleArray)
            {
                //If user is not a member then redirect to homepage.
                if (!UserManager.IsInRole(user.Id, role))
                {
                    rolecount++;
                }
            }
            if(rolecount == 0)
            {
                return false;
            }
            return true;
        }

        public static bool doesUserHaveAllRolePermissions(string roleName)
        {
            ApplicationDbContext ApplicationDbContext = new ApplicationDbContext();
            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ApplicationDbContext));
            var user = UserManager.FindById(HttpContext.Current.User.Identity.GetUserId());

            string[] roleArray = roleName.Split(',');
            foreach (string role in roleArray)
            {
                //If user is not a member then redirect to homepage.
                if (!UserManager.IsInRole(user.Id, role))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
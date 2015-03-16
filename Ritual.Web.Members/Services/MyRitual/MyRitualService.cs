using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Ritual.Data;
using Ritual.Web.Members.Models;

namespace Ritual.Web.Members.Services.MyRitual
{
    public class MyRitualService
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        private static RitualDBEntities db = new RitualDBEntities();

        public static MyRitualDashboardData GetModelForMyRitual(ApplicationUser user)
        {
            MyRitualDashboardData model = new MyRitualDashboardData();
            Member member = db.Members.Single(m => m.AspNetUserId == user.Id);
            model.Gravatar = string.Format("<img src='{0}' class='gravatar'/>", user.PhotoUrl);
            model.UserMember = member;
            model.UserHomeLocation = member.getUserHomeLocation();
            model.UserActiveMembership = member.getActiveMembership();
            model.UserPastMemberships = member.getExpiredMemberships();

            if (model.UserActiveMembership != null)
            {
                model.DaysTillMembershipExpiry = member.getActiveMembership().daysTillExpiry();
            }

            return model;
        }


        public static MembershipProfileEditViewModel GetModelForMyRitualEditProfile(ApplicationUser user)
        {
            MembershipProfileEditViewModel model = new MembershipProfileEditViewModel();
            Member member = db.Members.Single(m => m.AspNetUserId == user.Id);
            model.AddressLine1 = member.AddressLine1;
            model.AddressLine2 = member.AddressLine2;
            model.City = member.City;
            model.Country = member.Country;
            model.Countries = new SelectList(IEnumerables.GetCountries(), "ID", "Name", model.Country);
            model.PostCodeZip = member.PostZipCode;
            model.ShirtSize = !string.IsNullOrEmpty(member.ShirtSize) ? member.ShirtSize.Trim() : string.Empty;
            model.ShirtSizes = new SelectList(IEnumerables.GetShirtSizes(), "ID", "Name", model.ShirtSize);
            model.ShortSize = !string.IsNullOrEmpty(member.ShortSize) ? member.ShortSize.Trim() : string.Empty;
            model.ShortSizes = new SelectList(IEnumerables.GetShortSizes(), "ID", "Name", model.ShortSize);
            model.IDNumber = !string.IsNullOrEmpty(member.IDNumber) ? member.IDNumber.Trim() : string.Empty;
            model.IDType = !string.IsNullOrEmpty(member.IDType) ? member.IDType.Trim() : string.Empty;
            model.IDTypes = new SelectList(IEnumerables.GetIDTypes(), "ID", "Name", model.IDType);
            model.EmergencyContactName = !string.IsNullOrEmpty(member.EmergencyContactName) ? member.EmergencyContactName.Trim() : string.Empty;
            model.EmergencyContactNumber = !string.IsNullOrEmpty(member.EmergencyContactNumber) ? member.EmergencyContactNumber.Trim() : string.Empty;
            model.HomePhone = !string.IsNullOrEmpty(user.HomePhone) ? user.HomePhone.Trim() : string.Empty;
            model.MobilePhone = !string.IsNullOrEmpty(user.MobilePhone) ? user.MobilePhone.Trim() : string.Empty;
            model.Birthday = Convert.ToDateTime(user.Birthday);
            model.EmailOptOut = member.EmailOptOut;
            
            return model;
        }
        
        public async static void SaveMyRitualEditProfile(ApplicationUser user, MembershipProfileEditViewModel model)
        {

            Member member = db.Members.Single(m => m.AspNetUserId == user.Id);
            member.ShirtSize = model.ShirtSize.Trim();
            member.ShortSize = model.ShortSize.Trim();
            member.AddressLine1 = model.AddressLine1;
            member.AddressLine2 = model.AddressLine2;
            member.BloodType = model.BloodType;
            member.City = model.City;
            member.Country = model.Country;
            member.PostZipCode = model.PostCodeZip;
            member.IDNumber = model.IDNumber;
            member.IDType = model.IDType;
            member.EmergencyContactName = model.EmergencyContactName;
            member.EmergencyContactNumber = model.EmergencyContactNumber;
            member.EmailOptOut = model.EmailOptOut;
            db.Entry(member).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Ritual.Data;
using Ritual.Web.Admin.Models;

namespace Ritual.Web.Admin.Services
{
    public class MembersService
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        private static RitualDBEntities db = new RitualDBEntities();

        public static MembershipEditViewModel GetModelForMyRitualEditProfile(ApplicationUser user, Member member)
        {
            MembershipEditViewModel model = new MembershipEditViewModel();
            model.MemberId = member.Id;
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
            model.BloodType = member.BloodType;
            model.BloodTypes = new SelectList(IEnumerables.GetBloodTypes(), "ID", "Name", model.BloodType);
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Salutation = user.Salutation;
            model.Salutations = new SelectList(IEnumerables.GetSalutations(), "ID", "Name", model.Salutation);
            model.Gender = user.Gender;
            model.Genders = new SelectList(IEnumerables.GetGenders(), "ID", "Name", model.Gender);

            return model;
        }

        public static void SaveMyRitualEditProfile(MembershipEditViewModel model, Member member)
        {
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
        }
    }
}
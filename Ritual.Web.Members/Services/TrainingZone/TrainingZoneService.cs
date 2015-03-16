using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Ritual.Data;
using Ritual.Web.Members.Models;

namespace Ritual.Web.Members.Services.TrainingZone
{
    public class TrainingZoneService
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        private static RitualDBEntities db = new RitualDBEntities();


        public static bool isUserAllowedBooking(Member member, int locationId, TimeSlot timeslot)
        {
            if (member.HomeLocationId != locationId)
            {
                return false;
            }

            if (!member.hasActiveMembership())
            {
                return false;
            }

            if (member.hasActiveMembership())
            {
                if (member.getActiveMembership().getMembershipType() == "Off-Peak" && !timeslot.IsOffPeakSlot(locationId))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
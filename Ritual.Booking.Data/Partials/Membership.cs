using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ritual.Booking.Data
{
    public class MembershipsDetailData
    {
        public Membership Membership { get; set; }
    }

    [MetadataType(typeof(MembershipMetadata))]
    public partial class Membership
    {
        private RitualDBEntities db = new RitualDBEntities();
        public int getNumberOfSuspensions()
        {
            return db.MembershipSuspensions.Where(s => s.MembershipId == this.MemberId).Count();
        }

        public int daysTillExpiry()
        {
            return Convert.ToInt32((this.EndDate - DateTime.Now).TotalDays);
        }
    }
}

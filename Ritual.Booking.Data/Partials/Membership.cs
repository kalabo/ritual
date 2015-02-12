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

    public class MembershipListingData
    {
        public IEnumerable<Membership> Memberships { get; set; }
        public string StartDateSortParam { get; set; }
        public string EndDateSortParam { get; set; }
    }

    public class MembershipsSuspensionData
    {
        public Membership Membership { get; set; }
        public Package Package { get; set; }
    }

    public class SuspendMembershipModel
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public Membership suspendMembership { get; set; }
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
        
        public bool allowSuspension()
        {
            if(this.getNumberOfSuspensions() < this.Package.PackageSuspensionLimit)
            {
                return true;
            }

            if(this.Package.PackageSuspensionLimit > 0)
            {
                return true;
            }

            return false;
        }
    }
}

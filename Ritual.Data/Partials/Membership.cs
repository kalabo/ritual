using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Ritual.Data
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
            return db.MembershipSuspensions.Count(s => s.MembershipId == this.MemberId);
        }
        
        public string getMembershipType()
        {
            string memberType;
            if (this.Package.PackageType.Name == "Off-Peak")
            {
                memberType = "Off-Peak";
            }
            else if (this.Package.PackageType.Name == "Standard")
            {
                memberType = "Peak";
            }
            else
            {
                memberType = "Session";
            }   
            return memberType;
        }

        public string getMembershipStatusText()
        {
            string html = string.Empty;
            switch (this.MembershipState.Name)
            {
                case "Active":
                    if (this.StartDate > DateTime.Now)
                    {
                        html = "Your membership will start in " + this.daysTillStart() + " days.";
                    }
                    else
                    {
                        html = "Your membership will expire in " + this.daysTillExpiry() + " days.";
                    }
                    break;
                case "Expired":
                    html = "I'm afriad your membership has expired";
                    break;
                default:
                    html = "You do not currently have an active membership.  If you would like to sign up for a new membership please visit your nearest Ritual Gym.";
                    break;
            }
            return html;
        }

        public int daysTillExpiry()
        {
            return Convert.ToInt32((this.EndDate - DateTime.Now).TotalDays);
        }

        public int daysTillStart()
        {
            return Convert.ToInt32((this.StartDate - DateTime.Now).TotalDays);
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

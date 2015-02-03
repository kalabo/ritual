using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ritual.Booking.Data
{
    public class MemberDetailData
    {
        public Member Member { get; set; }
        public IEnumerable<Membership> Memberships { get; set; }
        public IEnumerable<QuarterlyAssessment> QuarterlyAssessments { get; set; }
    }

    [MetadataType(typeof(MemberMetadata))]
    public partial class Member
    {
        private RitualDBEntities db = new RitualDBEntities();

        [Column("FullName", TypeName = "string")]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        public bool hasActiveMembership()
        {
            if(this.getActiveMembership() != null)
            {
                return true;
            }
            return false;
        }

        public Member getMemberById()
        {
            return db.Members.Where(m => m.AspNetUserId == this.AspNetUserId).Single();
        }

        public Location getUserHomeLocation()
        {
            return db.Locations.Where(l => l.Id == this.HomeLocationId).FirstOrDefault();
        }

        public Membership getActiveMembership()
        {
            return db.Memberships.Where(m => m.MemberId == this.Id && m.MembershipStateId == 1).FirstOrDefault();
        }

        public List<Membership> getExpiredMemberships()
        {
            return db.Memberships.Where(m => m.MemberId == this.Id && m.MembershipStateId != 1).ToList();            
        }

        public List<SessionBooking> getUpcomingBookings(int limit)
        {
            return db.SessionBookings.Where(m => m.MemberId == this.Id && m.LocationId == this.HomeLocationId && m.Date >= DateTime.Now).OrderByDescending(m => m.Date).ThenBy(m => m.TimeSlot.StartTime).Take(limit).ToList(); 
        }

        public List<SessionBooking> getPastBookings(int limit)
        {
            return db.SessionBookings.Where(m => m.MemberId == this.Id && m.LocationId == this.HomeLocationId && m.Date < DateTime.Now).OrderByDescending(m => m.Date).ThenBy(m => m.TimeSlot.StartTime).Take(limit).ToList();
        }

        public List<QuarterlyAssessment> getQuarterlyAssessments(int limit)
        {
            return db.QuarterlyAssessments.Where(qa => qa.MemberId == this.Id).OrderByDescending(qa => qa.QADateTime).Take(limit).ToList();
        }
    }
}

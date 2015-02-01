using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ritual.Booking.Data
{
    public class TrainingZoneDashboardData
    {
        public Location UserHomeLocation { get; set; }
        public Member UserMember { get; set; }
        public int DaysTillMembershipExpiry { get; set; }
        public int BookingsInLastThirtyDays { get; set; }
        public OpeningHour TodaysOpeningHours { get; set; }
        public Membership UserActiveMembership { get; set; }
        public IEnumerable<SessionBooking> UpcomingBookings { get; set; }
        public IEnumerable<SessionBooking> PastBookings { get; set; }
        public IEnumerable<SessionBooking> MissedBookings { get; set; }
        public IEnumerable<QuarterlyAssessment> QuarterlyAssessments { get; set; }
    }

    public class TrainingZoneMyRitualData
    {
        public Location UserHomeLocation { get; set; }
        public Member UserMember { get; set; }
        public int DaysTillMembershipExpiry { get; set; }
        public Membership UserActiveMembership { get; set; }
        public IEnumerable<Membership> UserPastMemberships { get; set; }
    }

    public class TrainingZoneConfirmBooking
    {
        public DateTime bookingDate { get; set; }
        public Location bookingLocation { get; set; }
        public Member bookingMember { get; set; }
        public TimeSlot bookingTimeslot { get; set; }
    }

    public class TrainingZoneCancelBooking
    {
        public SessionBooking sessionBooking { get; set; }
    }

    public class TrainingZoneBookingData
    {
        public IEnumerable<GetNextBookingSlotsWindow_Result> AvailableBookingSlots { get; set; }
    }
}

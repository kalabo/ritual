using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ritual.Data
{
    public class TrainingZoneDashboardData
    {
        public Location UserHomeLocation { get; set; }
        public Member UserMember { get; set; }
        public int DaysTillMembershipExpiry { get; set; }
        public int BookingsInLastThirtyDays { get; set; }
        public OpeningHour TodaysOpeningHours { get; set; }
        public Membership UserActiveMembership { get; set; }
        public IEnumerable<QuarterlyAssessment> QuarterlyAssessments { get; set; }
    }

    public class MembershipSuspensionViewModel
    {
        public int SuspensionMembershipId { get; set; }

        public int SuspensionMemberId { get; set; }

        [Display(Name = "Suspensions Days Remaining")]
        public int AvailableSuspensionDays { get; set; }

        [Display(Name = "Suspensions Days Taken")]
        public int TakenSuspensionDays { get; set; }

        [Display(Name = "Suspensions Taken")]
        public int CurrentMembershipSuspensions { get; set; }

        [Display(Name = "Suspension Package Limit")]
        public int CurrentMembershipPackageSuspensionLimit { get; set; }

        [Display(Name = "Suspension Start Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SuspensionStartDate { get; set; }

        [Display(Name = "Suspension End Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SuspensionEndDate { get; set; }

        [Display(Name = "Suspension Reason")]
        public string SuspensionReason { get; set; }
    }

    public class MyRitualDashboardData
    {
        public string Gravatar { get; set; }
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
        public bool AllowBooking { get; set; }
        public bool SendEmailConfirmation { get; set; }
    }

    public class TrainingZoneCancelBooking
    {
        public SessionBooking sessionBooking { get; set; }
    }

    public class TrainingZoneBookingData
    {
        public IEnumerable<GetUpcomingBookingSlots_Result> AvailableBookingSlots { get; set; }
        public List<DateTime> OpenDays { get; set; }
        public string MemberType { get; set; }
        public Member currentMember { get; set; }
    }
}

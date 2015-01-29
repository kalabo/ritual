using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ritual.Booking.Data
{
    public class TrainingZoneDashboardData
    {
        public IEnumerable<SessionBooking> UpcomingBookings { get; set; }
        public IEnumerable<SessionBooking> PastBookings { get; set; }
        public IEnumerable<SessionBooking> MissedBookings { get; set; }
        public IEnumerable<QuarterlyAssessment> QuarterlyAssessments { get; set; }
    }
}

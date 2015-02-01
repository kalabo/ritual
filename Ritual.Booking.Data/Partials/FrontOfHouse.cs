using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ritual.Booking.Data
{
    public class FrontOfHouse
    {
    }


    public class FrontOfHouseCheckInData
    {
        public List<GetImminentSessionBookings_Result> NextSessionData { get; set; }
    }

    public class FrontOfHouseConfirmCheckInData
    {
        public SessionBooking UserHomeLocation { get; set; }
        public Member UserMember { get; set; }
    }
}

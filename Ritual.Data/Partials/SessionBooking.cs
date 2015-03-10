using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ritual.Data
{
    public partial class SessionBooking
    {
    }
    //Model User for Json Serialisation of News
    public partial class SessionBookingJSONModel
    {
        public int Id { get; set; }
        public string BookingState { get; set; }
        public string MemberName { get; set; }
        public string Location { get; set; }
        public TimeSpan StartTime { get; set; }
        public int RPEFeeling { get; set; }
        public int RPEPush { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeSlotDateTime { get; set; }
    }

    //Model User for Json Serialisation of News
    public partial class SessionBookingModel
    {
        public int Id { get; set; }
        public string BookingState { get; set; }
        public string MemberName { get; set; }
        public string Location { get; set; }
        public TimeSpan StartTime { get; set; }
        public int RPEFeeling { get; set; }
        public int RPEPush { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeSlotDateTime { get; set; }
    }
}

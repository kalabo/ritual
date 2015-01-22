using Ritual.Booking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ritual.Booking.Web.Models
{
    public class MemberIndexData
    {
        public IEnumerable<QuarterlyAssessment> QuarterlyAssessments { get; set; }
    }
}
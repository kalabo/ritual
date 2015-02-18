using Ritual.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ritual.Web.Members.Models
{
    public class MemberIndexData
    {
        public IEnumerable<QuarterlyAssessment> QuarterlyAssessments { get; set; }
    }
}
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
        [Column("FullName", TypeName = "string")]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }
    }
}
